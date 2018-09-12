using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Program
    { 
        static double VectDistanceQuad(int x1, int x2, int y1, int y2)
        {
            return (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
        }

        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());

            double distance1 = VectDistanceQuad(x2, x3, y2, y3);
            double distance2 = VectDistanceQuad(x2, x1, y2, y1);
            double distance3 = VectDistanceQuad(x1, x3, y1, y3);

            var half = (distance3 - distance2 + distance1) / (2 * Math.Sqrt(distance1));
            Console.WriteLine(Math.Sqrt(distance3 - (half * half)));
            Console.ReadKey();
        }
    }
}
