namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            // Количество проходов (например, вправо до стенки, вниз до стенки и т.д.)
            int countMove = height - 2;
            for (int i = 0; i < countMove; i++)
            {
                if (i % 2 == 1)
                    MoveTwoDown(robot);
                else if ((i / 2) % 2 == 0)
                    MoveRight(robot, width);
                else
                    MoveLeft(robot, width);
            }
		}
        // Переходит на новую линию лабиринта
        public static void MoveTwoDown(Robot robot)
        {
            robot.MoveTo(Direction.Down);
            robot.MoveTo(Direction.Down);
        }
        // Проходит вдоль лабиринта влево 
        public static void MoveLeft(Robot robot, int width)
        {
            for (int i = 0; i < (width - 3); i++)
                robot.MoveTo(Direction.Left);
        }
        // Проходит вдоль лабиринта вправо 
        public static void MoveRight(Robot robot, int width)
        {
            for (int i = 0; i < (width - 3); i++)
                robot.MoveTo(Direction.Right);
        }
    }
}