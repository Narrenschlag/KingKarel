using System;

namespace KingKarel
{
    internal class Program
    {
        public static bool loaded = false;
        public static Level level;

        static void Main(string[] args)
        {
            Game.setup();

            // Updates the console
            Backend.doNothing();

            try
            {
                Game.run();
            }
            catch (Exception ex)
            {
                error(ex);
                return;
            }

            waitForInputs(args);
        }

        static void waitForInputs(string[] args)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.R:
                    Main(args);
                    break;

                default:
                    waitForInputs(args);
                    break;
            }
        }

        static void error(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Error: " + exception.Message);
        }
    }
}