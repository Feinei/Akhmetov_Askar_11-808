using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursMinuteAngle
{
    class Program
    {
        static void Main(string[] args)
        {
            double hours = double.Parse(Console.ReadLine());
            double minutes = double.Parse(Console.ReadLine());
            hours = minutes / 60 + hours;
            hours = hours * 5;
            var angle = 6 * Math.Abs(hours - minutes);
            if (angle > 180)
            {
                angle = 360 - angle;
            }
            Console.WriteLine(angle);
            Console.ReadKey();
        }
    }
}
