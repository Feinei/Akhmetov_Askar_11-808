using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServer
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("10.17.4.93"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        Console.WriteLine("Читаю");
                    }
                    while (handler.Available > 0);
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
                    //"INSERT INTO movies VALUES('film23', 'videojopa', 1922, 'comedy', 'USA', 679300::money);"
                    var request = builder.ToString();
                    var connection = new NpgsqlConnection("Host=localhost;User Id=som;Password=123;Database=filmography;");
                    var comand = new NpgsqlCommand(request, connection);
                    comand.CommandText = request.Split(';')[0] + ';';
                    connection.Open();

                    switch (request.Split()[0].ToUpper())
                    {
                        case "INSERT":
                            comand.ExecuteNonQuery(); 
                            break;
                        case "SELECT":
                            NpgsqlDataReader reader;
                            reader = comand.ExecuteReader();

                            while (reader.Read())
                            {
                                handler.Send(Encoding.Unicode.GetBytes(reader.GetValue(0).ToString()));
                            }
                            connection.Close();
                            break;
                        case "DELETE":
                            handler.Send(Encoding.Unicode.GetBytes("SOSIJOPY"));
                            break;
                        default:
                            break;
                    }                  

                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
