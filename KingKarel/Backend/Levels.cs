using System.Numerics;

namespace KingKarel
{
    internal class Levels
    {
        public static void Load(Level level)
        {
            Program.loaded = false;
            Program.level = level;
        }

        #region Living Room
        public static Level livingRoom = new Level()
        {
            start = new Vector2(0, 0),
            size = new Vector2(6, 5),
            title = "livingRoom",
            beepers = 0,

            walls = new Vector2[]
            {
                new Vector2(3, 0),
                new Vector2(3, 1),
                new Vector2(3, 2),
                new Vector2(4, 2),
                new Vector2(5, 2)
            },

            drops = new Vector2[]
            {
                new Vector2(4, 3)
            }
        };
        #endregion

        #region Empty 10x10
        public static Level empty10x10 = new Level()
        {
            size = new Vector2(10, 10),
            start = new Vector2(0, 0),
            title = "empty10x10"
        };
        #endregion
    }

    public class Level
    {
        public Vector2[] walls, drops;
        public Vector2 size, start;
        public string title;
        public int beepers;
    }
}