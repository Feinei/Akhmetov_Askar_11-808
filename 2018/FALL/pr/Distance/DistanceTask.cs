using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        // Вычисляет длину отрезка по координатам 
        public static double GetLength(double x1, double y1, double x2, double y2)
        {
            var x0 = x1 - x2;
            var y0 = y1 - y2;
            return Math.Sqrt(x0 * x0 + y0 * y0);
        }

        // Находит косинус угла по теореме косинусов 
        public static double GetCos (double segment1, double segment2, double segment3)
        {
            var numerator = segment1 * segment1 + segment2 * segment2 - segment3 * segment3;
            if ((numerator == 0) || (segment1 == 0) || (segment2 == 0))
                return 0;
            else
                return numerator / (2 * segment1 * segment2);
        }
		// Расстояние от точки O(x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            // Длинна отрезков: AB
            var mainSegment = GetLength(ax, ay, bx, by);
            // OA
            var bSegment = GetLength(ax, ay, x, y);
            // OB
            var aSegment = GetLength(bx, by, x, y);

            // Если тупой угол или точка лежит на отрезке, то перпендикуляр не является расстоянием 
            if ((Math.Acos(GetCos(bSegment, mainSegment, aSegment)) >= Math.PI / 2) || 
               (Math.Acos(GetCos(aSegment, mainSegment, bSegment)) >= Math.PI / 2))
            {
                if (aSegment > bSegment)
                    return bSegment;
                else
                    return aSegment;
            }
            else
            {
                 var partOfMainSegment = bSegment * GetCos(bSegment, mainSegment, aSegment);
                return Math.Sqrt(bSegment * bSegment - partOfMainSegment * partOfMainSegment);
            }
		}
	}
}