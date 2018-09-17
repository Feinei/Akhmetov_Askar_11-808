using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOf3n5
{
    class Program
    {
        static void Main(string[] args)
        {
            int count3 = 999 / 3;
            int count5 = 999 / 5;
            int count3and5 = 999 / 15;
            int sum3 = (3 + 999) * count3 / 2;
            int sum5 = (5 + 995) * count5 / 2;
            int sum3and5 = (15 + 990) * count3and5 / 2;
            Console.WriteLine(sum3 + sum5 - sum3and5);
            Console.ReadKey();
        }
    }
}
