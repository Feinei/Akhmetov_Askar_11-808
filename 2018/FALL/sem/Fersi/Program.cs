using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            var doska = new bool[4,4];
            for (int i = 0; i < doska.GetLength(0); i++)
                for (int j = 0; j < doska.GetLength(1); j++)
                    doska[i, j] = false;
            MakeCombinations(doska, 4, 0);
            Console.WriteLine(count);
            Console.ReadKey();
        }

        static void MakeCombinations(bool[,] doska, int elementsLeft, int position)
        {
            if (elementsLeft == 0)
            {
                count++;
                return;
            }

            if (position == doska.GetLength(0))
                return;

            for (int j = 0; j < doska.GetLength(0); j++)
                if (!doska[position, j])
                {
                    doska[position, j] = true;
                    for (int x = 0; x < doska.GetLength(0); x++)
                        for (int y = 0; y < doska.GetLength(1); y++)
                            if (y == j || x == position || Math.Abs(x - position) == Math.Abs(y - j))
                                doska[x, y] = true;
                    MakeCombinations(doska, elementsLeft - 1, position + 1);
                    doska[position, j] = false;
                    MakeCombinations(doska, elementsLeft, position + 1);
                    break;
                }
        }
    }
}
