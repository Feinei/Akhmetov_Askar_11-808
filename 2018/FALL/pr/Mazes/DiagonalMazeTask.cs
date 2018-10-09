namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
        {
            int longMove = GetLongMove(width, height);

            for (int i = 0; i < GetCountMove(width,height,longMove); i++)
            {
                // Чередуем длинный и короткий шаги
                if (i % 2 == 0)
                    MoveLong(robot, width, height, longMove);
                else
                    MoveShort(robot, width, height, longMove);
            }
        }
        // Вычисляет длинный шаг 
        public static int GetLongMove(int width, int height)
        {
            if (width < height)
                return (height - 2) / (width - 2);
            else 
                return (width - 2) / (height - 2);
        }
        // Количество ходов до упора
        public static int GetCountMove (int width, int height, int longMove)
        {
            if (width < height)
                return (width - 3) + ((height - 3) / longMove);
            else
                return (height - 3) + ((width - 3) / longMove);
        }
        // Делает длинный шаг
        public static void MoveLong(Robot robot, int width, int height, int longMove)
        {            
            if (width < height)
                for (int i = 0; i < longMove; i++)
                    robot.MoveTo(Direction.Down);
            else
                for (int i = 0; i < longMove; i++)
                    robot.MoveTo(Direction.Right);
        }
        // Делает короткий единичный шаг
        public static void MoveShort(Robot robot, int width, int height, int longMove)
        {
            if (width < height)
                robot.MoveTo(Direction.Right);
            else
                robot.MoveTo(Direction.Down);
        }
    }
}