using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSocket
{
    class ServerSocket
    {
        private static int port = 34000;

        static void Main(string[] args)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, port);

            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);

            // начинаем пsрослушивание
            listenSocket.Listen(10);

            var serverIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
            Console.WriteLine("Ip адрес сервера: " + serverIp + ", порт: " + port);
            Console.WriteLine("Сервер запущен.");

            while (true)
            {
                var handler = listenSocket.Accept();
                try
                {
                    //отправляем ключ RSA
                    handler.Send(Encoding.UTF8.GetBytes(RSA.ToXmlString(false)));
                    
                    //получаем DES
                    byte[] byteDES = RSA.Decrypt(Helper.RecieveMes(handler), true);
                    MyDES myDES = Helper.ByteArrayToObject(byteDES) as MyDES;
                    DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                    DES.Key = myDES.key;
                    DES.IV = myDES.IV;
                    
                    //получаем количество строчек
                    int count = (int)Helper.ByteArrayToObject(Helper.RecieveMes(handler));

                    //отправляем ответ о получении данных
                    handler.Send(new byte[] { 1, 2, 3 });

                    for (int i = 0; i < count; i++)
                    {
                        //получаем данные
                        Record record = Helper.ByteArrayToRecord(Helper.RecieveMes(handler), DES);
                        //переносим в нормализованую бд
                        record.WriteToNormalizeDb();
                    }

                    // отправляем ответ
                    string message = "Ваше сообщение доставлено";
                    byte[] info = Encoding.Unicode.GetBytes(message);
                    handler.Send(info);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
        }
    }
}
