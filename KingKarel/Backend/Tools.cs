using System.Collections.Generic;
using System.Text;
using System;
using System.Threading;

namespace KingKarel
{
    internal static class Tools
    {
        public static void draw(this string text, ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(text);
            Console.ForegroundColor = old;
        }

        public static void wait() => Thread.Sleep((int)Math.Round(Game.timeBetweenFrames * 1000));
    }
}
