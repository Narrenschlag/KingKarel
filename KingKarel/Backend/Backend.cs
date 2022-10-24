using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System.Linq;
using System;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace KingKarel
{
    internal class Backend
    {
        private static Map map => Map.instance;

        private static int direction = 0;
        private static Vector2 position;
        private static int beepers;

        private static Vector2 beeperCountGrid;
        private static Vector2 historyGrid;

        private static List<string> history;
        private static int turn;

        #region Direction Checks
        public static bool frontIsBlocked() => !frontIsClear();
        public static bool frontIsClear()
        {
            clampDir();
            return map.CanWalkTo(position, FrontPosition);
        }

        public static bool rightIsClear() => map.CanWalkTo(position, RightPosition);
        public static bool rightIsBlocked() => !rightIsClear();

        public static bool leftIsClear() => map.CanWalkTo(position, LeftPosition);
        public static bool leftIsBlocked() => !leftIsClear();

        public static bool beepersPresent() => map.BeepersAt(position) > 0;
        public static bool noBeepersPresent() => !beepersPresent();

        public static bool noBeepersInBag() => !beepersInBag();
        public static bool beepersInBag() => beepers > 0;

        public static bool facingEast() => direction == 0;
        public static bool facingSouth() => direction == 1;
        public static bool facingWest() => direction == 2;
        public static bool facingNorth() => direction == 3;

        public static bool notFacingEast() => !facingEast();
        public static bool notFacingSouth() => !facingSouth();
        public static bool notFacingWest() => !facingWest();
        public static bool notFacingNorth() => !facingNorth();
        #endregion

        #region Actions
        public static void move()
        {
            clampDir();

            Vector2 next = FrontPosition;

            // Check if player can walk there
            if (!map.CanWalkTo(position, next)) throw new Exception("Cannot walk into walls");

            // Can walk here
            else
            {
                Vector2 old = position;
                position = next;

                update($"Moved from {old} to {next}");
                Tools.wait();
            }
        }

        public static void turnLeft()
        {
            direction--;
            clampDir();

            update("Turned left");
            Tools.wait();
        }

        public static void putBeeper()
        {
            int old = map.BeepersAt(position);

            if (beepers > 0)
            {
                map.ModifyBeepers(position, +1);
                beepers--;
            }
            else throw new Exception("You don't have any beepers to put");

            update($"Put beeper ({old} -> {map.BeepersAt(position)})");
            Tools.wait();
        }

        public static void pickBeeper()
        {
            int old = map.BeepersAt(position);

            if (map.BeepersAt(position) > 0)
            {
                map.ModifyBeepers(position, -1);
                beepers++;
            }
            else throw new Exception("No beeper has been found at that position");

            update($"Picked beeper ({old} -> {map.BeepersAt(position)})");
            Tools.wait();
        }

        public static void doNothing()
        {
            update("Did nothing");
            Tools.wait();
        }
        #endregion

        #region Private Functions
        private static void clampDir()
        {
            if (direction > 3) direction = direction % 4;
            else if (direction < 0) direction = 4 - (Math.Abs(direction) % 4);
        }
        #endregion

        #region References
        private static Vector2 FrontPosition
        {
            get
            {
                Vector2 next = position;
                switch (direction)
                {
                    case 0:
                        next.X++;
                        break;

                    case 1:
                        next.Y--;
                        break;

                    case 2:
                        next.X--;
                        break;

                    case 3:
                        next.Y++;
                        break;

                    default: break;
                }

                return next;
            }
        }

        private static Vector2 RightPosition => position + RightOff;
        private static Vector2 LeftPosition => position - RightOff;

        private static Vector2 RightOff
        {
            get
            {
                Vector2 next = Vector2.Zero;
                switch (direction)
                {
                    case 0:
                        next.Y--;
                        break;

                    case 1:
                        next.X--;
                        break;

                    case 2:
                        next.Y++;
                        break;

                    case 3:
                        next.X++;
                        break;

                    default: break;
                }

                return next;
            }
        }
        #endregion

        public static void onLoadMap()
        {
            Backend.beepers = map.level.beeperCountStart;
            position = map.level.start;

            history = new List<string>();
            turn = 0;
        }

        private static void update(string turnInfo)
        {
            if (turn == 0)
            {
                #region Console Preperation
                // Clear console
                Tools.clear();

                // Console title
                Console.CursorVisible = false;
                Console.Title = map.level.title;
                Console.SetWindowPosition(0, 0);
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                #endregion
            }

            // Draw map
            map.draw(position, direction);

            if (turn == 0)
            {
                #region Beeper Count
                "".drawLine();
                string beeperText = "Beeper Count: ";
                beeperText.draw(ConsoleColor.Magenta);

                beeperCountGrid = new Vector2(beeperText.Length, Console.CursorTop);
                #endregion

                #region History
                if (turn > 0) history.Insert(0, turnInfo);

                "".drawLine();
                "".drawLine();

                "History".draw(ConsoleColor.Magenta);
                ("   " + (1 / HelloKarel.timeBetweenFrames).ToString("n1").Replace(",", ".") + "/sec").draw(ConsoleColor.Gray);

                // Writes the last ten(10) turns down
                "".drawLine();
                historyGrid = new Vector2(Console.CursorLeft, Console.CursorTop);
                #endregion
            }

            // Beeper count
            string beepers = Backend.beepers > 99 ? "99+" : Backend.beepers.ToString();
            beepers += "     ";
            beepers.drawAt(beeperCountGrid);

            // Action history
            if (turn > 0) history.Insert(0, turnInfo);
            for (int i = 0; i < 10 && i < history.Count; i++)
                ($"{turn - i - 1}: {history[i]}" + "                        ").drawAt((int)historyGrid.X, (int)historyGrid.Y + i);

            // Increase turn count
            turn++;
        }
    }
}