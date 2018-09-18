using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			// Не слишком ли высоко находится r1 от r2, не слишком ли низко находится r1 от r2, ...
			return !((r1.Top > r2.Top + r2.Height) || (r2.Top > r1.Top + r1.Height) || (r1.Left > r2.Left + r2.Width)||(r2.Left > r1.Left + r1.Width));
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (AreIntersected(r1, r2))
                {
                  // Ширина пересечения
                  var width = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
                  // Высота пересечения
                  var height = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);
			      return width * height;
                }
            else return 0;
		}

        // Находится ли r2 в r1
        public static bool CompareRectangle(int r1Top, int r1Bottom, int r1Left, int r1Right, int r2Top, int r2Bottom, int r2Left, int r2Right)
        {
            return (r1Top <= r2Top) && (r1Bottom >= r2Bottom) && (r1Left <= r2Left) && (r1Right >= r2Right);    
        }
            
		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (CompareRectangle(r1.Top, r1.Bottom, r1.Left, r1.Right, r2.Top, r2.Bottom, r2.Left, r2.Right))
                 return 1;
            else if (CompareRectangle(r2.Top, r2.Bottom, r2.Left, r2.Right, r1.Top, r1.Bottom, r1.Left, r1.Right))
                      return 0;
                 else return -1;         
		}
	}
}		