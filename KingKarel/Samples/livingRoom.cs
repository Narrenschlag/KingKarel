namespace KingKarel.Samples
{
    internal class livingRoom : Backend
    {
        public void setup()
        {
            Levels.Load(Levels.livingRoom);
        }

        public void run()
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