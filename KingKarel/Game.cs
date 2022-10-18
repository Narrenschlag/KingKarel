﻿namespace KingKarel
{
    internal class Game : Backend
    {
        public const float timeBetweenFrames = .4f;

        // Runs when application is started
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

        // Runs after setup
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