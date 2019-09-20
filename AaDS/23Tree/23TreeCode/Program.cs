using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestrTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Task();
            task.FillDict("I like potatos and you");
            task.CheckText("potato luck lake");
            Console.ReadKey();
        }
    }
}
