using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ServerSocket
{
    public static class Helper
    {
        public static byte[] RecieveMes(Socket socket)
        {
            
            // получаем сообщение
            List<byte> builder = new List<byte>();
            int bytes = 0; // количество полученных байтов
            byte[] data = new byte[256]; // буфер для получаемых данных
            do
            {
                bytes = socket.Receive(data);
                for (int i = 0; i < bytes; i++)
                    builder.Add(data[i]);
            } while (socket.Available > 0);

            return builder.ToArray();
        }

        public static void SendMes(IModel channel, string nameQueue, byte[] body)
        {
            channel.BasicPublish("",
                nameQueue,
                null,
                body);

            Console.WriteLine("Сообщение доставлено в очередь " + nameQueue);
        }

        public static byte[] RecieveMes(IModel channel, string nameQueue)
        {
            var consumer = new EventingBasicConsumer(channel);

            byte[] data = null;

            consumer.Received += (model, ea) =>
            {
                data = ea.Body.ToArray();
            };
            
            string tag = channel.BasicConsume(nameQueue,
                true,
                consumer);

            while (data == null)
            { }
            channel.BasicCancelNoWait(tag);
            Console.WriteLine("Сообщение принято из очереди " + nameQueue);
            return data;
        }

        public static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static Record ByteArrayToRecord(byte[] arrBytes, DES des)
        {
            using (var decryptor = des.CreateDecryptor())
            {
                var temp = decryptor.TransformFinalBlock(arrBytes, 0, arrBytes.Length);
                return ByteArrayToObject(temp) as Record;
            }
        }
        public static byte[] RecordToByteArray(Record obj, DES des)
        {
            using (var encryptor = des.CreateEncryptor())
            {
                var temp = ObjectToByteArray(obj);
                return encryptor.TransformFinalBlock(temp, 0, temp.Length);
            }
        }
    }
}
