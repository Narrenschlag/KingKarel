using System.Collections.Generic;
using System.Numerics;

namespace KingKarel
{
    internal class Levels
    {
        public static void Load(Level level) => new Map(level);

        #region Living Room
        public static Level livingRoom = new Level()
        {
            start = new Vector2(0, 0),
            size = new Vector2(10, 10),
            title = "livingRoom",
            beeperCountStart = 0,

            walls = new Vector2[]
            {
                new Vector2(6, 0),
                new Vector2(6, 1),
                new Vector2(6, 2),
                new Vector2(7, 2),
                new Vector2(8, 2),
                new Vector2(9, 2)
            },

            beepers = new KeyValuePair<Vector2, int>[]
            {
                new KeyValuePair<Vector2, int>(new Vector2(7, 3), 1)
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

        #region Double Beepers
        public static Level doubleBeepers = new Level()
        {
            size = new Vector2(5, 5),
            start = new Vector2(0, 0),
            title = "doubleBeepers",
            beeperCountStart = 99999,

            beepers = new KeyValuePair<Vector2, int>[]
            {
                new KeyValuePair<Vector2, int>(new Vector2(1, 0), 5)
            },

            walls = new Vector2[0]
        };
        #endregion
    }

    public class Level
    {
        public KeyValuePair<Vector2, int>[] beepers;
        public Vector2[] walls;

        public int beeperCountStart;
        public Vector2 size, start;
        public string title;
    }
}