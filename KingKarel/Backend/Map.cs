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
        private const string artEmpty = "*";
        private const string artWall = "█";

        private Vector2 oldPosition;
        private bool mapDrawn;

        public Map(Level level)
        {
            oldPosition = level.start;
            this.level = level;
            mapDrawn = false;
            instance = this;

            beepers = new Dictionary<Vector2, int>();
            if (level.beepers != null)
                foreach (Beeper b in level.beepers)
                    beepers.Add(b.point, b.count);

            Backend.onLoadMap();
        }

        int GetRow(Vector2 v2)
        {
            v2 = Vector2.Clamp(v2, Vector2.Zero, level.size);
            return (int)level.size.Y - (int)v2.Y;
        }

        int GetX(Vector2 v2)
        {
            v2 = Vector2.Clamp(v2, Vector2.Zero, level.size);
            return ((int)v2.X * 3 - 2) + (3 * 3);
        }

        public void draw(Vector2 player, int direction)
        {
            // Draw map once
            if (mapDrawn == false)
            {
                for (int y = (int)level.size.Y; y >= -2; y--)
                {
                    for (int x = -2; x < level.size.X + 1; x++)
                    {
                        ConsoleColor color = ConsoleColor.DarkGray;
                        Vector2 point = new Vector2(x, y);
                        string spaceLine = " ";

                        // Out of bounds
                        if (x < 0 || y < 0 || x >= level.size.X || y >= level.size.Y)
                        {
                            // Number grid
                            if (x < -1 || y < -1)
                            {
                                if (!InBounds(x, level.size.X) && !InBounds(y, level.size.Y)) spaceLine += " ";
                                else spaceLine += x < 0 ? y : x;
                            }

                            // Border
                            else
                            {
                                drawWall(ConsoleColor.DarkGray);
                                continue;
                            }
                        }

                        // In bounds
                        else
                        {
                            // Walls
                            if (level.isWall(point))
                            {
                                drawWall();
                                continue;
                            }

                            // Beepers
                            else if (beepers.ContainsKey(point))
                            {
                                spaceLine += beepers[point];
                                color = ConsoleColor.Yellow;
                            }

                            // Nothing
                            else
                            {
                                spaceLine += artEmpty;
                            }
                        }

                        // Draw space
                        if (spaceLine.Length < 3) spaceLine += " ";
                        spaceLine.draw(color);
                    }

                    // Start new line
                    "".drawLine(ConsoleColor.White);

                    void drawWall(ConsoleColor color = ConsoleColor.DarkGray)
                    {
                        for (int i = 0; i < 3; i++)
                            artWall.draw(color);
                    }
                }
            }

            // Draw Player
            {
                "*".drawAt(GetX(oldPosition), GetRow(oldPosition));
                artPlayer[direction].ToString().drawAt(GetX(player), GetRow(player), ConsoleColor.Red);
            }

            oldPosition = player;
            mapDrawn = true;
        }

        public bool InBounds(Vector2 position) => InBounds(position.X, level.size.X) && InBounds(position.Y, level.size.Y);
        public bool InBounds(float x, float size) => x >= 0 && x < size;

        public bool CanWalkTo(Vector2 position, Vector2 newPosition) => !level.isWall(newPosition) && InBounds(newPosition);

        public int BeepersAt(Vector2 position) => beepers.TryGetValue(position, out int i) ? i : 0;
        public void ModifyBeepers(Vector2 position, int modifier)
        {
            if (BeepersAt(position) < 1) beepers.Add(position, 0);

            beepers[position] += modifier;

            if (beepers[position] < 1) beepers.Remove(position);
        }
    }
}