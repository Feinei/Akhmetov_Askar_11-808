using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInfTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static IEnumerable<int> FirstTask(int[] seq)
        {
            var index = 0;
            return seq
                .Select(numb => numb * ++index)
                .Where(numb => numb > 9 && numb < 100)
                .Reverse();
        }

        static Tuple<string, int, int> ThirdTask(IEnumerable<Product> B, IEnumerable<Sale> C,
                                                              IEnumerable<Cost> D, IEnumerable<Purchase> E)
        {
            return Tuple.Create("ne yspel(", 0, 0);
        }
    }

    static class IEnumerableExtension
    {
        static IEnumerable<Tuple<T1, T2>> SecondTask<T1, T2>(
            this IEnumerable<T1> firstSeq, IEnumerable<T2> secondSeq)
        {
            return firstSeq
                .Join(secondSeq,
                t1 => t1,
                t2 => t2,
                (t1, t2) => Tuple.Create(t1, t2));
                
        }
    }
}
