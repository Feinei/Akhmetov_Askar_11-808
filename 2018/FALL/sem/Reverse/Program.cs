using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberStr = Console.ReadLine();
            int numberLength = numberStr.Length;
            int number = int.Parse(numberStr);
            
            for (int i = 0, j = numberLength ; i < numberLength / 2; i++ , j--)
            {
                
            }
            Console.ReadKey();
        }
    }
}
