using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace KingKarel
{
    internal class Map
    {
        private Dictionary<Vector2, int> beepers;
        public static Map instance;
        public Level level;

        private const string artPlayer = "►▼◄▲";
        private const string artEmpty = ".";
        private const string artWall = "■";

        public Map(Level level)
        {
            this.level = level;
            instance = this;

            beepers = new Dictionary<Vector2, int>();
            if (level.beepers != null)
                foreach (KeyValuePair<Vector2, int> b in level.beepers)
                    beepers.Add(new Vector2(b.Key.X, b.Key.Y), b.Value);

            Backend.onLoadMap();
        }

        public void draw(Vector2 player, int direction)
        {
            for (int y = (int)level.size.Y; y >= -2; y--)
            {
                for (int x = -2; x < level.size.X + 1; x++)
                {
                    Vector2 point = new Vector2(x, y);

                    // Out of bounds
                    if (x < 0 || y < 0 || x >= level.size.X || y >= level.size.Y)
                    {
                        // Number grid
                        if (x < -1 || y < -1)
                        {
                            if (!InBounds(x, level.size.X) && !InBounds(y, level.size.Y)) " ".draw(ConsoleColor.White);
                            else (x < 0 ? (y%10).ToString() : (x % 10).ToString()).draw(ConsoleColor.White);
                        }

                        // Border
                        else
                        {
                            artWall.draw(ConsoleColor.Red);
                        }
                    }

                    // In bounds
                    else
                    {
                        // Walls
                        if(level.walls != null)
                        if (level.walls.Contains(point))
                        {
                            artWall.draw(ConsoleColor.Red);
                        }

                        // Player
                        else if (point == player)
                        {
                            artPlayer[direction].ToString().draw(ConsoleColor.Yellow);
                        }

                        // Beepers
                        else if (beepers.ContainsKey(point))
                        {
                            beepers[point].ToString().draw(ConsoleColor.Yellow);
                        }

                        // Nothing
                        else
                        {
                            artEmpty.draw(ConsoleColor.DarkGray);
                        }
                    }

                    // Draw space
                    " ".draw(ConsoleColor.White);
                }

                // Start new line
                "".drawLine(ConsoleColor.White);
            }
        }

        public bool InBounds(Vector2 position) => InBounds(position.X, level.size.X) && InBounds(position.Y, level.size.Y);
        public bool InBounds(float x, float size) => x >= 0 && x < size;

        public bool CanWalkTo(Vector2 position, Vector2 newPosition) => !level.walls.Contains(newPosition) && InBounds(newPosition);

        public int BeepersAt(Vector2 position) => beepers.TryGetValue(position, out int i) ? i : 0;
        public void ModifyBeepers(Vector2 position, int modifier)
        {
            if (BeepersAt(position) < 1) beepers.Add(position, 0);

            beepers[position] += modifier;

            if (beepers[position] < 1) beepers.Remove(position);
        }
    }
}