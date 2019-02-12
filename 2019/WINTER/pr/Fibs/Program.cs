using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibs
{
    class Matrix2X2
    {
        private int A11;
        private int A12;
        private int A21;
        private int A22;

        public Matrix2X2(int a11, int a12, int a21, int a22)
        {
            A11 = a11;
            A12 = a12;
            A21 = a21;
            A22 = a22;
        }
        // Умножение матрицы 1х2 на матрицу 2х2
        public int[] Multiplicate(int[] matrixOf2, Matrix2X2 matrix)
        {
            return new int[] { matrix.A11 * matrixOf2[0] + matrix.A12 * matrixOf2[1],
                               matrix.A21 * matrixOf2[0] + matrix.A22 * matrixOf2[1]};
        }
        // Возведение матрицы в степень
        public void Pow(int power)
        {
            var standartMatrix = new Matrix2X2(A11, A12, A21, A22);
            for(int i = 1; i <= power; i++)
            {
                // Быстрое перемножение матриц
                if (i % 2 == 0 && i * 2 <= power)
                {        
                    var a11 = A11 * A11 + A12 * A21;
                    var a12 = A11 * A12 + A12 * A22;
                    var a21 = A21 * A11 + A22 * A21;
                    var a22 = A21 * A12 + A22 * A22;
                    A11 = a11; A12 = a12; A21 = a21; A22 = a22;
                    i *= 2;
                }
                else
                {
                    var a11 = A11 * standartMatrix.A11 + A12 * standartMatrix.A21;
                    var a12 = A11 * standartMatrix.A12 + A12 * standartMatrix.A22;
                    var a21 = A21 * standartMatrix.A11 + A22 * standartMatrix.A21;
                    var a22 = A21 * standartMatrix.A12 + A22 * standartMatrix.A22;
                    A11 = a11; A12 = a12; A21 = a21; A22 = a22;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix2X2(0, 1, 1, 1);
            matrix.Pow(6);
            // Первый эллемент - число фибоначи
            Console.WriteLine(matrix.Multiplicate(new int[] { 0, 1 }, matrix)[0]);
            Console.ReadKey();
        }
    }
}
