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
            for (int i = 0; i < 100; i++)
                if (beepersPresent()) pickBeeper();
                else break;
        }

        // Move until the right is not blocked anymore
        void moveUntilNoRight()
        {
            for (int i = 0; i < 100; i++)
                if (rightIsBlocked() && frontIsClear()) moveAndPick();
                else break;
        }

        // Move until there is wall ahead
        void moveUntilWall()
        {
            for (int i = 0; i < 100; i++)
                if (frontIsClear()) moveAndPick();
                else break;
        }

        #region No Recursion
        void noRecursion()
        {
            // Pre Condition
            // Karel stands x steps in front of a shaft
            //
            // Post Condition
            // Karel cleared the shafts beepers and is
            // standing behind the entrance of the shaft
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
        // Pre Condition
        // Karel stands x steps in front of a shaft
        //
        // Post Condition
        // Karel cleared the shafts beepers and is
        // standing behind the entrance of the shaft
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