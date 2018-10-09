namespace Mazes
{
	public static class EmptyMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            MoveHeight(robot, height);
            MoveWidth(robot, width);
        }

        public static void MoveHeight (Robot robot, int height)
        {
            for (int i = 0; i < (height - 3); i++)
                robot.MoveTo(Direction.Down);
        }
        
        public static void MoveWidth(Robot robot, int width)
        {
            for (int i = 0; i < (width - 3); i++)
                robot.MoveTo(Direction.Right);
        }
	}
}