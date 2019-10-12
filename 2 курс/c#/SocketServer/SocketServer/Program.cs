using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SocketTcpServer
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        static void Main(string[] args)
        {
            var fieldBuilder = new StringBuilder();
            fieldBuilder.Append("\n | | \n | | \n | | ");
            var turn = 'x';
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("10.17.1.35"), port);

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

                    var request = builder.ToString();

                    if (request != "st")
                    {
                        fieldBuilder[int.Parse(request) * 2 - 1] = turn;
                        if (turn == 'x')
                            turn = 'O';
                        else
                            turn = 'x';
                    }

                    handler.Send(Encoding.Unicode.GetBytes(fieldBuilder.ToString()));
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