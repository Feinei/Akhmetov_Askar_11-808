using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareySequence
{
    class FarSequence
    {
        LinkedList<Fraction> sequence;
        int seqOrder;

        public FarSequence(int seqOrder)
        {
            sequence = new LinkedList<Fraction>();
            sequence.AddLast(new Fraction { Numerator = 0, Denominator = 1 });
            sequence.AddLast(new Fraction { Numerator = 1, Denominator = 1 });
            this.seqOrder = seqOrder;
        }
        
        public void FillSequence()
        {
            LinkedListNode<Fraction> node;
            for (var order = 2; order <= seqOrder; order++)
                for (node = sequence.First; node != sequence.Last; node = node.Next)
                {
                    if (CanBetweenAdd(node.Value, node.Next.Value, order))
                        sequence.AddAfter(node, new Fraction
                        {
                            Numerator = node.Value.Numerator + node.Next.Value.Numerator,
                            Denominator = node.Value.Denominator + node.Next.Value.Denominator
                        });
                }
        }

        public bool CanBetweenAdd(Fraction fraction0, Fraction fraction1, int n)
        {
            return fraction0.Denominator + fraction1.Denominator == n;
        }

        public void Print()
        {
            foreach (var fraction in sequence)
                fraction.Print();
        }
    }
}
