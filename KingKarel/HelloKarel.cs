namespace KingKarel
{
    internal class HelloKarel : Backend
    {
        public const float timeBetweenFrames = .01f;

        // Runs when application is started
        public void setup()
        {
            Levels.Load(Levels.DiamondMining1);
        }

        // Turn by 180°
        void turnAround()
        {
            for (int i = 0; i < 2; i++) turnLeft();
        }

        // Turn right
        void turnRight()
        {
            for (int i = 0; i < 3; i++) turnLeft();
        }

        // Move and pick beepers if there
        void moveAndPick()
        {
            // Move
            move();

            // Check for beepers at position
            // and pick them up
            while (beepersPresent()) pickBeeper();
        }

        // Move until the right is not blocked anymore
        void moveUntilNoRight()
        {
            while (rightIsBlocked() && frontIsClear()) moveAndPick();
        }

        // Move until there is wall ahead
        void moveUntilWall()
        {
            while (frontIsClear()) moveAndPick();
        }

        #region No Recursion
        void noRecursion()
        {
            while (frontIsClear())
            {
                // Walk to next cave
                moveUntilNoRight();

                // Stop if reached wall
                if (frontIsBlocked()) break;

                // Turn into cave (south)
                turnRight();

                // Move once to enter
                moveAndPick();

                // Move until front is clear
                moveUntilWall();

                // Turn into the left shaft if existant
                if (rightIsClear())
                {
                    turnRight();
                    moveUntilWall();

                    // Turn into right shaft (east)
                    turnAround();

                    // Safety Step
                    moveAndPick();
                }

                // Else turn into right shaft (east)
                else turnLeft();

                // Pick up everything in that shaft
                moveUntilWall();

                // Turn around (west)
                turnAround();

                // Safety Step
                moveAndPick();

                // Move back to the shaft opening
                moveUntilNoRight();

                // Turn north
                turnRight();

                // Climp out of the shaft one step
                moveAndPick();

                // Climb up the rest of the shaft
                moveUntilNoRight();

                // Turn east
                turnRight();

                // Move one step
                moveAndPick();
            }
        }
        #endregion

        #region recursion
        void recursion()
        {
            if (frontIsBlocked()) return;

            // Walk to next cave
            moveUntilNoRight();

            // Stop if reached wall
            if (frontIsBlocked()) return;

            // Turn into cave (south)
            turnRight();

            // Move once to enter
            moveAndPick();

            // Move until front is clear
            moveUntilWall();

            // Turn into the left shaft if existant
            if (rightIsClear())
            {
                turnRight();
                moveUntilWall();

                // Turn into right shaft (east)
                turnAround();

                // Safety Step
                moveAndPick();
            }

            // Else turn into right shaft (east)
            else turnLeft();

            // Pick up everything in that shaft
            moveUntilWall();

            // Turn around (west)
            turnAround();

            // Safety Step
            moveAndPick();

            // Move back to the shaft opening
            moveUntilNoRight();

            // Turn north
            turnRight();

            // Climp out of the shaft one step
            moveAndPick();

            // Climb up the rest of the shaft
            moveUntilNoRight();

            // Turn east
            turnRight();

            // Move one step
            moveAndPick();

            // Recurse
            recursion();
        }
        #endregion

        // Runs after setup
        public void run()
        {
            noRecursion();
        }
    }
}