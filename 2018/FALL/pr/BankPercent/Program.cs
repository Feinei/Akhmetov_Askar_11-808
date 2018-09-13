using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPercent
{
    class Program
    {
        public static double Calculate(string userInput)
        {
            var parts = userInput.Split();
            var money = double.Parse(parts[0]);
            var percent = double.Parse(parts[1]);
            var month = int.Parse(parts[2]);
            double monthPercent = 1 + percent / 1200;
            money = money * monthPercent;
            return (money * Math.Pow(monthPercent, month - 1));
        }

        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            Console.WriteLine(Calculate(userInput));
            Console.ReadKey();
        }
    }
}
