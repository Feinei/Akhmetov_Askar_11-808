using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueTurn
{
    class Program
    {  
        static string TrueTurn (string from, string to, string name)
        {
            bool check = false;
            // по буквам
            var turn0 = Math.Abs(from[0] - to[0]);
            // по номеру
            var turn1 = Math.Abs(from[1] - to[1]);

            if ((name == "слон") && (turn0 == turn1))
                check = true;
            else if ((name == "конь") && (((turn0 == 1) && (turn1 == 2)) || ((turn0 == 2) && (turn1 == 1))))
                check = true;
            else if ((name == "ладья") && ((turn0 == 0) || (turn1 == 0)))
                check = true;
            else if ((name == "ферзь") && ((turn0 == turn1) || (turn0 == 0) || (turn1 == 0)))
                check = true;
            else if ((name == "король") && (turn0 < 2) && (turn1 < 2))
                check = true;

            if (check)
                return "Правильный ход!";
            else return "Фигура так не ходит!";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Откуда ходит фигура?");
            string turnFrom = Console.ReadLine();
            Console.WriteLine("Куда ходит фигура?");
            string turnTo = Console.ReadLine();
            Console.Write("Название фигуры: ");
            string figure = Console.ReadLine();

            Console.WriteLine(TrueTurn(turnFrom, turnTo, figure));
            Console.ReadKey();
        }
    }
}
