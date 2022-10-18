using System;

namespace KingKarel
{
    internal class Program
    {
        public static Game game;

        static void Main(string[] args)
        {
            game = new Game();
            game.setup();

            // Updates the console
            Backend.doNothing();

            try
            {
                game.run();
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