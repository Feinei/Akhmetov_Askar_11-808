<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareySequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var seqOrder = int.Parse(Console.ReadLine());
            var farSequence = new FarSequence(seqOrder);
            farSequence.FillSequence();
            farSequence.Print();
            Console.ReadKey();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareySequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var seqOrder = int.Parse(Console.ReadLine());
            var farSequence = new FarSequence(seqOrder);
            farSequence.FillSequence();
            farSequence.Print();
            Console.ReadKey();
        }
    }
}
>>>>>>> 2fb0e1c20ffaad2b148384ab52ce02ed767bc6b4
