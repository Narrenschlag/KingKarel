namespace KingKarel
{
    internal class HelloKarel : Backend
    {
        public const float timeBetweenFrames = .2f;

        // Runs when application is started
        public void setup()
        {
            Levels.Load(Levels.Pyramid);
        }

        // Turn right
        void turnRight()
        {
            for (int i = 0; i < 3; i++) turnLeft();
        }

        // Runs after setup
        public void run()
        {
            for (int i = 0; i < 5; i++)
            {
                if(i > 0) move();
                putBeeper();
            }

            turnLeft();
            move();
            turnLeft();
            move();

            for (int i = 0; i < 3; i++)
            {
                if (i > 0) move();
                putBeeper();
            }

            turnRight();
            move();
            turnRight();
            move();

            for (int i = 0; i < 1; i++)
            {
                if (i > 0) move();
                putBeeper();
            }

            move();
        }
    }
}