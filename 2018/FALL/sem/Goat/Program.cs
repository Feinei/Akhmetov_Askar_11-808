using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goat
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSquar = double.Parse(Console.ReadLine());
            double rad = double.Parse(Console.ReadLine());
            double area;

            if (rad <= sideSquar / 2)
            {
                area = Math.PI * rad * rad;
            }
            else
            {
                if (rad >= Math.Sqrt(2) * sideSquar / 2)
                {
                    area = sideSquar * sideSquar;
                }
                else
                {
                    double angleTriangle = 2 * Math.Acos(sideSquar / 2 / rad);
                    double areaTriangle = sideSquar / 2 * Math.Sqrt(rad * rad - (sideSquar * sideSquar) / 4);
                    double areaCone = Math.PI * rad * rad * angleTriangle / 360;
                    double areaSeq = areaCone - areaTriangle;
                    area = rad * rad * Math.PI - 4 * areaSeq;
                }
            }
            Console.WriteLine(area);
            Console.ReadKey();
        }
    }
}
