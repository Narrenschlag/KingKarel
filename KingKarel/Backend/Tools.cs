using System.Threading;
using System.Text;
using System;

namespace KingKarel
{
    internal static class Tools
    {
        public static void drawLine(this string text, ConsoleColor color) => draw($"\n{text}", color);
        public static void drawLine(this string text) => draw($"\n{text}");

        public static void draw(this string text) => text.append();
        public static void draw(this string text, ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;

            // Flush so there is no string left
            flush();

            Console.Write(text);
            Console.ForegroundColor = old;
        }

        public static void wait() => Thread.Sleep((int)Math.Round(HelloKarel.timeBetweenFrames * 1000));

        private static StringBuilder txt = new StringBuilder();

        public static void append(this string txt) => Tools.txt.Append(txt);
        public static void flush()
        {
            Console.Write(txt.ToString());
            txt.Clear();
        }
    }
}
