using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArr
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[6];
            for(int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int k = int.Parse(Console.ReadLine());
            Array.Reverse(arr);
            Array.Reverse(arr, 0, k);
            Array.Reverse(arr, k, arr.Length - k);

            foreach (var e in arr)
                Console.WriteLine(e);
            Console.ReadKey();
        }
    }
}
