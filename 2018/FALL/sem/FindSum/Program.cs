using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // длинна массива
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            // необходимая сумма
            var x = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(Console.ReadLine());

            int startInd = 0;
            int endInd = n - 1;
            while (startInd != endInd)
            {
                var sum = array[startInd] + array[endInd];
                if (sum < x)
                    startInd++;
                else if (sum > x)
                    endInd--;
                else
                {
                    Console.WriteLine(array[startInd]);
                    Console.WriteLine(array[endInd]);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
