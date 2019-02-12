using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareySequence
{
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public void Print()
        {
            Console.WriteLine(Numerator + "/" + Denominator);
        }
    }
}
