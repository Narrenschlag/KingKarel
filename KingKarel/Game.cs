namespace KingKarel
{
    internal class Game : Backend
    {
        public const float timeBetweenFrames = .5f;

        public static void setup()
        {
            Levels.Load(Levels.empty10x10);
        }

        public static void run()
        {

        }
    }
}