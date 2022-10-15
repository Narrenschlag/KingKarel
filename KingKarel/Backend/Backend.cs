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

        private static List<string> history;
        private static int turn;

        #region Direction Checks
        public static bool frontIsBlocked() => !frontIsClear();
        public static bool frontIsClear()
        {
            clampDir();
            return map.CanWalkTo(position, FrontPosition);
        }

        public static bool rightIsClear() => map.CanWalkTo(position, position + new Vector2(1, 0));
        public static bool rightIsBlocked() => !rightIsClear();

        public static bool leftIsClear() => map.CanWalkTo(position, position + new Vector2(-1, 0));
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

            Vector2 NEW = FrontPosition;

            // Check if player can walk there
            if (!map.CanWalkTo(position, NEW)) throw new Exception("Cannot walk into walls");

            // Can walk here
            else
            {
                Vector2 old = position;
                position = NEW;

                update($"Moved from {old} to {NEW}");
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

        public static void doNothing() => update("Did nothing");
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
                Vector2 NEW = position;
                switch (direction)
                {
                    case 0:
                        NEW.X++;
                        break;

                    case 1:
                        NEW.Y--;
                        break;

                    case 2:
                        NEW.X--;
                        break;

                    case 3:
                        NEW.Y++;
                        break;

                    default: break;
                }

                return NEW;
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
            #region Console Preperation
            // Clear console
            Console.Clear();

            // Console title
            Console.Title = map.level.title;
            #endregion

            // Draw map
            map.draw(position, direction);

            #region Beeper Count
            "".drawLine();
            string beepers = Backend.beepers > 99 ? "99+" : Backend.beepers.ToString();
            $"Beeper Count: {beepers}".draw();
            #endregion

            #region History
            if (turn > 0) history.Insert(0, turnInfo);
            turn++;

            "".drawLine();
            "".drawLine();

            "History".draw(ConsoleColor.Magenta);
            ("   " + (1 / Game.timeBetweenFrames).ToString("n1").Replace(",", ".") + "/sec").draw(ConsoleColor.Gray);

            // Writes the last ten(10) turns down
            "".drawLine();
            for (int i = 0; i < 10 && i < history.Count; i++)
                ($"{turn - i - 1}: {history[i]}").drawLine();
            #endregion

            // Flush console text
            Tools.flush();
        }
    }
}