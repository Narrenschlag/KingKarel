using System.Threading;
using System.Text;
using System;
namespace KingKarel
{
    internal static class Tools
    {
        public static void drawLine(this string text, ConsoleColor color) => draw($"\n{text}", color);
        public static void drawLine(this string text) => draw($"\n{text}");

        public static void draw(this string text, ConsoleColor color = default)
        {
            if (color.Equals(default)) color = Tools.color;

            if(color != Tools.color)
            {
                flush();
                Tools.color = color;
            }

            Tools.text.Append(text);
        }

        public static void wait() => Thread.Sleep((int)Math.Round(HelloKarel.timeBetweenFrames * 1000));

        private static StringBuilder text = new StringBuilder();
        private static ConsoleColor color = ConsoleColor.White;

        public static void flush()
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(text.ToString());
            text.Clear();

            Console.ForegroundColor = old;
        }
    }
}
