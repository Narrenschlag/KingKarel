using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Drawing;

namespace KingKarel
{
    internal class Backend
    {
        private static Dictionary<Vector2, int> drops;

        private static int direction = 0;
        private static Vector2 position;
        private static int beepers;

        private const string artPlayer = "►▼◄▲";
        private const string artEmpty = ".";
        private const string artWall = "■";

        private static List<string> history;
        private static int turn;

        #region Direction Checks
        private static bool isFree(Vector2 position)
        {
            if (position.X < 0 || position.Y < 0 || position.X >= Program.level.size.X || position.Y >= Program.level.size.Y) return false;
            if (Program.level.walls.Contains(position)) return false;

            return true;
        }

        public static bool frontIsBlocked() => !frontIsFree();
        public static bool frontIsFree()
        {
            clampDir();
            return isFree(FrontPosition);
        }

        public static bool rightIsBlocked() => !rightIsFree();
        public static bool rightIsFree() => isFree(position + new Vector2(1, 0));

        public static bool downIsBlocked() => !downIsFree();
        public static bool downIsFree() => isFree(position + new Vector2(0, -1));

        public static bool leftIsBlocked() => !leftIsFree();
        public static bool leftIsFree() => isFree(position + new Vector2(-1, 0));

        public static bool upIsBlocked() => !upIsFree();
        public static bool upIsFree() => isFree(position + new Vector2(0, 1));

        public static bool beeperHere() => drops.ContainsKey(position);
        #endregion

        #region Actions
        public static void move()
        {
            clampDir();

            Vector2 NEW = FrontPosition;

            // Check if player can walk there
            if(Program.level.walls.Contains(NEW)) throw new Exception("Cannot walk into walls");

            // Can walk here
            else
            {
                Thread.Sleep((int)Math.Round(Game.timeBetweenFrames * 1000));
                Vector2 old = position;
                position = NEW;

                update($"Moved from {old} to {NEW}");
            }
        }

        public static void turnLeft()
        {
            direction--;
            clampDir();

            Thread.Sleep((int)Math.Round(Game.timeBetweenFrames * 1000));
            update("Turned left");
        }

        public static void pickBeeper()
        {
            if (drops.ContainsKey(position))
            {
                drops[position]--;
                beepers++;

                if (drops[position] < 1) drops.Remove(position);
            }
            else throw new Exception("No beeper has been found at that position");
        }

        public static void putBeeper()
        {
            if (beepers > 0)
            {
                if (!drops.ContainsKey(position)) drops.Add(position, 0);
                drops[position]++;
                beepers--;
            }
            else throw new Exception("You don't have any beepers to put");
        }

        public static void doNothing() => update("Did nothing");
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

        private static void update(string turnInfo)
        {
            Level level = Program.level;

            if(!Program.loaded)
            {
                drops = new Dictionary<Vector2, int>();
                if(level.drops != null)
                    foreach (Vector2 v2 in level.drops)
                        drops.Add(new Vector2(v2.X, v2.Y), 1);

                Backend.beepers = level.beepers;
                position = level.start;
                Program.loaded = true;

                history = new List<string>();
                turn = 0;
            }

            // Clears the console
            Console.Clear();

            // Console title
            Console.Title = level.title;
            
            // Each row
            for (int y = (int)Math.Floor(level.size.Y); y >= -1; y--)
            {
                Console.WriteLine("");

                // Each row element
                for (int x = -1; x < level.size.X + 1; x++)
                {
                    Vector2 position = new Vector2(x, y);

                    // Place walls around the room
                    if (y < 0 || x < 0 || y >= level.size.Y || x >= level.size.X) draw(artWall, ConsoleColor.Red);

                    // Place player with direction
                    else if (Backend.position == position) draw(artPlayer[direction] + "", ConsoleColor.Cyan);

                    // Place walls that have been defined
                    else if (level.walls != null && level.walls.Contains(position)) draw(artWall, ConsoleColor.Red);

                    // Place drops that have been defines
                    else if (level.drops != null && drops.ContainsKey(position)) draw("" + drops[position], ConsoleColor.White);

                    // Place empty
                    else draw(artEmpty, ConsoleColor.Gray);

                    // Add a space for more approachable layout
                    draw(" ", ConsoleColor.White);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            string beepers = Backend.beepers > 99 ? "99+" : Backend.beepers.ToString();
            draw($"Beeper Count: " + beepers, ConsoleColor.White);

            if(turn > 0) history.Insert(0, turnInfo);
            turn++;

            Console.WriteLine();
            Console.WriteLine();
            draw("History", ConsoleColor.Magenta);

            // Writes the last ten(10) turns down
            Console.WriteLine();
            for (int i = 0; i < 10 && i < history.Count; i++)
                Console.WriteLine($"Turn {turn - i - 1}: {history[i]}");
        }
        
        private static void clampDir()
        {
            if (direction > 3) direction = direction % 4;
            else if (direction < 0) direction = 4 - (Math.Abs(direction) % 4);
        }

        private static void draw(string text, ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(text);
            Console.ForegroundColor = old;
        }
    }
}
