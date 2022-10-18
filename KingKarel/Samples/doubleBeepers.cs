namespace KingKarel.Samples
{
    internal class doubleBeepers : Backend
    {
        public void setup()
        {
            Levels.Load(Levels.doubleBeepers);
        }

        void recursive()
        {
            pickBeeper();

            if (beepersPresent()) recursive();

            // Place two new beepers
            for (int i = 0; i < 2; i++)
                putBeeper();
        }

        void turnAround()
        {
            for (int i = 0; i < 2; i++) turnLeft();
        }

        public void run()
        {
            while (noBeepersPresent()) move();

            recursive();
            turnAround();

            move();
            turnAround();
        }
    }
}