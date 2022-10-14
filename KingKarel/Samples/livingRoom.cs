namespace KingKarel.Samples
{
    internal class livingRoom : Backend
    {
        void Run()
        {
            while (frontIsClear())
                move();

            turnLeft();

            while (rightIsBlocked())
                move();

            for (int i = 0; i < 3; i++)
                turnLeft();

            while (!beeperHere())
                move();

            pickBeeper();

            while (frontIsClear())
                move();
        }
    }
}