namespace KingKarel
{
    internal class Game : Backend
    {
        public const float timeBetweenFrames = .1f;

        // Runs when application is started
        public void setup()
        {
            Levels.Load(Levels.doubleBeepers);
        }

        #region Recursion Sample
        void recursion()
        {
            // Pick up beeper
            pickBeeper();

            // Recurse until no beepers left
            if (beepersPresent()) recursion();

            // Place two new beepers for every picked beeper
            for (int i = 0; i < 2; i++) putBeeper();
        }
        #endregion

        #region No Recursion Sample
        void noRecursion()
        {
            // While beepers are at origin
            while (beepersPresent())
            {
                // Pick up beeper
                pickBeeper();

                // Move to the right
                move();

                // Place two new beepers at point to the right
                for (int i = 0; i < 2; i++) putBeeper();

                // Turn around
                turnAround();

                // Move to origin
                move();

                // Get into original position by turning around again
                turnAround();
            }

            // Move to the storage point
            move();

            // Turn around to get into new origin position
            turnAround();

            // While beepers are at storage
            while (beepersPresent())
            {
                // Pick up beeper
                pickBeeper();

                // Move to the left
                move();

                // Put beeper
                putBeeper();

                // Turn around
                turnAround();

                // Move to the right
                move();

                // Turn around to get back into original position
                turnAround();
            }

        }
        #endregion

        // Turn by 180°
        void turnAround()
        {
            for (int i = 0; i < 2; i++) turnLeft();
        }

        // Runs after setup
        public void run()
        {
            // Move to the beepers
            while (noBeepersPresent()) move();

            // Solution of your choice
            noRecursion();

            // Turn until facing west
            while (!facingWest()) turnLeft();

            // Move until wall is reached
            while(frontIsClear()) move();

            // Turn around to face east
            turnAround();
        }
    }
}