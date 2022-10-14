namespace KingKarel.Samples
{
    internal class livingRoom : Backend
    {
        void Run()
        {
            while (frontIsFree())
                move();

            turnLeft();

            while (rightIsBlocked())
                move();

            for (int i = 0; i < 3; i++)
                turnLeft();

            while (!beeperHere())
                move();

            pickBeeper();

            while (frontIsFree())
                move();
        }
    }
}