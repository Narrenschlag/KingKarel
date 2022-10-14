namespace KingKarel.Samples
{
    internal class livingRoom : Backend
    {
        public static void run()
        {
            while (frontIsClear())
                move();

            turnLeft();

            while (rightIsBlocked())
                move();

            for (int i = 0; i < 3; i++)
                turnLeft();

            while (!beepersPresent())
                move();

            pickBeeper();

            while (frontIsClear())
                move();
        }
    }
}