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

        #region DiamondMining2
        public static Level DiamondMining2 = new Level()
        {
            start = new Vector2(0, 4),
            size = new Vector2(15, 9),
            title = "mine",
            beeperCountStart = 0,

            walls = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(0, 2),
                new Vector2(0, 3),

                new Vector2(1, 0),

                new Vector2(2, 0),
                new Vector2(2, 2),
                new Vector2(2, 3),

                new Vector2(3, 0),
                new Vector2(3, 1),
                new Vector2(3, 2),
                new Vector2(3, 3),

                new Vector2(4, 0),
                new Vector2(4, 1),
                new Vector2(4, 3),

                new Vector2(5, 0),
                new Vector2(5, 1),

                new Vector2(6, 0),
                new Vector2(6, 1),
                new Vector2(6, 3),

                new Vector2(7, 0),
                new Vector2(7, 1),
                new Vector2(7, 2),
                new Vector2(7, 3),

                new Vector2(8, 0),
                new Vector2(8, 1),
                new Vector2(8, 2),
                new Vector2(8, 3),

                new Vector2(9, 0),
                new Vector2(9, 2),
                new Vector2(9, 3),

                new Vector2(10, 0),

                new Vector2(11, 0),
                new Vector2(11, 2),
                new Vector2(11, 3),

                new Vector2(12, 0),
                new Vector2(12, 1),
                new Vector2(12, 2),
                new Vector2(12, 3),

                new Vector2(13, 0),
                new Vector2(13, 1),
                new Vector2(13, 2),
                new Vector2(13, 3),

                new Vector2(14, 0),
                new Vector2(14, 1),
                new Vector2(14, 2),
                new Vector2(14, 3),
            },

            beepers = new KeyValuePair<Vector2, int>[]
            {
                new KeyValuePair<Vector2, int>(new Vector2(2, 1), 1),
                new KeyValuePair<Vector2, int>(new Vector2(4, 2), 1),
                new KeyValuePair<Vector2, int>(new Vector2(6, 2), 1),
                new KeyValuePair<Vector2, int>(new Vector2(10, 1), 1),
                new KeyValuePair<Vector2, int>(new Vector2(11, 1), 1),
            }
        };
        #endregion

        #region Mining3
        public static Level Mining3 = new Level()
        {
            start = new Vector2(0, 4),
            size = new Vector2(15, 9),
            title = "mine",
            beeperCountStart = 0,

            walls = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(0, 2),
                new Vector2(0, 3),

                new Vector2(1, 0),

                new Vector2(2, 0),
                new Vector2(2, 2),
                new Vector2(2, 3),

                new Vector2(3, 0),
                new Vector2(3, 1),
                new Vector2(3, 2),
                new Vector2(3, 3),

                new Vector2(4, 0),
                new Vector2(4, 1),
                new Vector2(4, 3),

                new Vector2(5, 0),
                new Vector2(5, 1),

                new Vector2(6, 0),
                new Vector2(6, 1),
                new Vector2(6, 3),

                new Vector2(7, 0),
                new Vector2(7, 1),
                new Vector2(7, 2),
                new Vector2(7, 3),

                new Vector2(8, 0),
                new Vector2(8, 1),
                new Vector2(8, 2),
                new Vector2(8, 3),

                new Vector2(9, 0),
                new Vector2(9, 2),
                new Vector2(9, 3),

                new Vector2(10, 0),

                new Vector2(11, 0),
                new Vector2(11, 2),
                new Vector2(11, 3),

                new Vector2(12, 0),
                new Vector2(12, 3),

                new Vector2(13, 0),
                new Vector2(13, 1),
                new Vector2(13, 2),
                new Vector2(13, 3),

                new Vector2(14, 0),
                new Vector2(14, 1),
                new Vector2(14, 2),
                new Vector2(14, 3),
            },

            beepers = new KeyValuePair<Vector2, int>[]
            {
                new KeyValuePair<Vector2, int>(new Vector2(14, 4), 1),
            }
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