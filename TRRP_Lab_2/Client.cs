using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerSocket;
using System.Data.SQLite;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Messaging;
using ServerMQ;
using RabbitMQ.Client;
using System.Threading;

namespace TRRP_Lab_2
{
    class Client
    {
        Socket socket;

        public List<Record> Records(string path)
        {
            using (var connect = new SQLiteConnection(@"Data Source=" + path + ";"))
            {
                try
                {
                    connect.Open();

                    var getTables = new SQLiteCommand()
                    {
                        Connection = connect,
                        CommandText = @"SELECT NAME from sqlite_master"
                    };
                    var tables = new List<string>();
                    var sqlReader = getTables.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        tables.Add(sqlReader[0].ToString());
                    }

                    if (tables.Count == 0)
                    {
                        throw new Exception(@"База данных не имеет таблиц");
                    }

                    var getRecords = new SQLiteCommand
                    {
                        Connection = connect,
                        CommandText = @"SELECT * FROM " + tables[0]
                    };

                    var records = new List<Record>();
                    sqlReader = getRecords.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        records.Add(new Record(sqlReader));
                    }

                    return records;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Client Records error");
                    return null;
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void SendSocket(List<Record> records, string address, int port)
        {
            try
            {
                if (socket == null)
                {
                    var ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // подключаемся к удаленному хосту
                    socket.Connect(ipPoint);                  
                }

                //получаем ключ RSA
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(Encoding.UTF8.GetString(Helper.RecieveMes(socket)));
                
                //отправляем DES
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.GenerateKey();
                DES.GenerateIV();
                byte[] byteDES = Helper.ObjectToByteArray(new MyDES(DES.Key, DES.IV));
                byte[] DESEncrypt = RSA.Encrypt(byteDES, true);
                socket.Send(DESEncrypt);
                
                //отправляем количество строчек
                socket.Send(Helper.ObjectToByteArray(records.Count));

                //принимаем ответ о получении данных
                Helper.RecieveMes(socket);
                
                for (int i = 0; i < records.Count; i++)
                {
                    socket.Send(Helper.RecordToByteArray(records[i], DES));
                }

                //Ответ
                var answer = Helper.RecieveMes(socket);
                MessageBox.Show("Ответ сервера: " + Encoding.Unicode.GetString(answer));

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Client sendSocket error");
            }
        }

        public void SendMQ(List<Record> records, string address, string username, string pass)
        {
            try
            {
                var factory = new ConnectionFactory();

                factory.UserName = username;
                factory.Password = pass;
                factory.VirtualHost = "/";
                factory.HostName = address;

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    //Асинхронный ключ шифрования
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                    RSA.FromXmlString(Encoding.UTF8.GetString(Helper.RecieveMes(channel, "RSA")));

                    //Синхронный ключ шифрования
                    DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                    DES.GenerateKey();
                    DES.GenerateIV();
                    byte[] byteDES = Helper.ObjectToByteArray(new MyDES(DES.Key, DES.IV));
                    byte[] DESEncrypt = RSA.Encrypt(byteDES, true);
                    Helper.SendMes(channel, "DES", DESEncrypt);

                    //отправляем записи
                    for (int i = 0; i < records.Count; i++, Console.WriteLine("kds"))
                        Helper.SendMes(channel, "records", Helper.RecordToByteArray(records[i], DES));
                }
                MessageBox.Show("Отправлено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Client sendMQ error");
            }
        }
    }
}
