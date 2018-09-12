using System;

namespace firstApp
{
    class Program
    {

        static void Main()
        {
            int angle;
            string hour = Console.ReadLine();
            int hourint = int.Parse(hour);
            if (hourint <= 6)
            {
                angle = hourint * 30;
            }
            else
            {
                angle = 360 - hourint * 30;
            }
            Console.WriteLine(angle);
            Console.ReadKey();
        }        
    }
}
