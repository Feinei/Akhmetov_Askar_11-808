using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboModul
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = 5;
            var fibo = new int[25];
            fibo[0] = 0;
            fibo[1] = 1;
            Console.WriteLine(fibo[0] + " " + fibo[1]);
            for (int i = 2; i < fibo.Length; i++)
            {
                fibo[i] = (fibo[i - 1] + fibo[i - 2]) % p;
                Console.WriteLine(fibo[i]);
            }
            Console.ReadKey();
        }
    }
}
