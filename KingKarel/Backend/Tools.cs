using System.Threading;
using System;
using System.Numerics;

namespace KingKarel
{
    internal static class Tools
    {
        public static void drawLine(this string text, ConsoleColor color) => draw($"\n{text}", color);
        public static void drawLine(this string text) => draw($"\n{text}");

        public static void draw(this string text, ConsoleColor color = ConsoleColor.DarkGray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);

            string[] lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }

        public static void drawAt(this string text, Vector2 grid, ConsoleColor color = ConsoleColor.DarkGray) => text.drawAt((int)grid.X, (int)grid.Y, color);
        public static void drawAt(this string text, int x, int y, ConsoleColor color = ConsoleColor.DarkGray)
        {
            // Save cursor values for reset
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;

            try
            {
                Console.SetCursorPosition(x, y);
                text.draw(color);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            // Reset the cursor
            Console.SetCursorPosition(oldX, oldY);
        }

        public static void wait() => Thread.Sleep((int)Math.Round(HelloKarel.timeBetweenFrames * 1000));

        public static void clear()
        {
            Console.Clear();
        }
    }
}