namespace KingKarel
{
    internal class Game : Backend
    {
        public const float timeBetweenFrames = .5f;

        // Runs when application is started
        public static void setup()
        {
            Levels.Load(Levels.livingRoom);
        }

        // Runs after setup
        public static void run()
        {

        }
    }
}