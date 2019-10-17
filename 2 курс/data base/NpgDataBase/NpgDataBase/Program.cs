using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;User Id=som;Password=123;Database=filmography;");
            NpgsqlCommand comand = new NpgsqlCommand(@"SELECT * FROM movies;", connection);
            connection.Open();
            NpgsqlDataReader reader;
            reader = comand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(2));
            }
            connection.Close();
        }
    }
}
