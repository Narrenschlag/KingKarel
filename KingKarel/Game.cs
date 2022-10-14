namespace KingKarel
{
    internal class Game : Backend
    {
        public const float timeBetweenFrames = .4f;

        // Runs when application is started
        public static void setup()
        {
            Levels.Load(Levels.livingRoom);
        }

        // Runs after setup
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