using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Размеры бруса: ");
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            Console.Write("Размеры отверстия: ");
            int holeHeigth = int.Parse(Console.ReadLine());
            int holeWidth = int.Parse(Console.ReadLine());

            if (((width <= holeWidth) && (heigth <= holeHeigth)) ||
                ((width <= holeHeigth) && (heigth <= holeWidth)) ||
                ((width <= holeWidth) && (length <= holeHeigth)) ||
                ((width <= holeHeigth) && (length <= holeWidth)) ||
                ((heigth <= holeWidth) && (length <= holeHeigth)) ||
                ((heigth <= holeHeigth) && (length <= holeWidth)))
                Console.WriteLine("Брус пролезает");
            else Console.WriteLine("Брус не пролезает");
            Console.ReadKey();
        }
    }
}
