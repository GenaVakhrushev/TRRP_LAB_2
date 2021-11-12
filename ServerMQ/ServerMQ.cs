using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServerSocket;

namespace ServerMQ
{
    public class ServerMQ
    {
        static void Main()
        {
            var RSA = new RSACryptoServiceProvider(2048);

            var serverIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
            Console.WriteLine("Ip адрес сервера: " + serverIp);
            Console.WriteLine("Сервер запущен.");

            var factory = new ConnectionFactory()
            {
                HostName = serverIp.ToString(),
                Password = "admin",
                UserName = "admin"
            }; 
            using (var connection = factory.CreateConnection())
            {
                while (true)
                {
                    using (var channel = connection.CreateModel())
                    {
                        Helper.SendMes(channel,
                            "RSA",
                            Encoding.UTF8.GetBytes(RSA.ToXmlString(false)));

                        //Синхронный ключ шифрования
                        var byteDES = RSA.Decrypt(Helper.RecieveMes(channel, "DES"), true);
                        var myDES = Helper.ByteArrayToObject(byteDES) as MyDES;
                        var DES = new DESCryptoServiceProvider()
                        {
                            Key = myDES.key,
                            IV = myDES.IV
                        };

                        //consumer for records
                        var consumer = new EventingBasicConsumer(channel);

                        byte[] data = null;

                        consumer.Received += (model, ea) =>
                        {
                            data = ea.Body.ToArray();
                            Record record = Helper.ByteArrayToRecord(data, DES);
                            record.WriteToNormalizeDb();
                            Console.WriteLine("Запись добавлена");
                        };

                        string tag = channel.BasicConsume("records",
                            true,
                            consumer);
                    }
                }
            }
        }
    }
}
