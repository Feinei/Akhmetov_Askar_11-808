using System;
using System.Drawing;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        // Начальная точка с коорд. (x, y)
        static double x = 1;
        static double y = 0;
        // Доп. переменные нужны для того, чтобы при подсчете новых "y" значения "x" не затирались
        static double xAddit;

        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            // Генератор случайных чисел
            var randomForFractal = new Random(seed);

            for (int i = 0; i < iterationsCount; i++)
            {
                var nextNumber = randomForFractal.Next(2);
                Draw(nextNumber, pixels);
            }
        }

        public static void Draw(int randNum, Pixels pixels)
        {
            // Если преобразование 1 :
            if (randNum == 0)
            {
                xAddit = x;
                x = (x * Math.Cos(Math.PI / 4) - y * Math.Sin(Math.PI / 4)) / Math.Sqrt(2);
                y = (xAddit * Math.Sin(Math.PI / 4) + y * Math.Cos(Math.PI / 4)) / Math.Sqrt(2);
            }
            // Иначе преобразование 2 :
            else
            {
                xAddit = x;
                x = (x * Math.Cos(3 * Math.PI / 4) - y * Math.Sin(3 * Math.PI / 4)) /
                         Math.Sqrt(2) + 1;
                y = (xAddit * Math.Sin(3 * Math.PI / 4) + y * Math.Cos(3 * Math.PI / 4)) / Math.Sqrt(2);
            }
            pixels.SetPixel(x, y);
        }
    }
}