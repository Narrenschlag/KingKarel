using System;
using System.Collections.Generic;
using System.Linq;
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

            wallChunks = new Chunk[]
            {
                new Chunk(6, 0, 9, 2)
            },

            beepers = new Beeper[]
            {
                new Beeper(7, 3)
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

            beepers = new Beeper[]
            {
                new Beeper(1, 0, 5)
            },

            walls = new Vector2[0]
        };
        #endregion

        #region DiamondMining1
        public static Level DiamondMining1 = new Level()
        {
            start = new Vector2(0, 16),
            size = new Vector2(50, 20),
            title = "mine",
            beeperCountStart = 0,

            wallChunks = new Chunk[]
            {
                new Chunk(0, 0, 49, 0),
                new Chunk(0, 1, 0, 15),
                new Chunk(1, 10, 2, 15),
                new Chunk(1, 1, 3, 8),
                new Chunk(4, 4, 9, 8),
                new Chunk(4, 10, 9, 15),
                new Chunk(4, 1, 19, 2),
                new Chunk(8, 9, 9, 9),
                new Chunk(11, 15, 15, 4),
                new Chunk(13, 3, 35, 2),
                new Chunk(16, 4, 26, 12),
                new Chunk(16, 14, 19, 15),
                new Chunk(21, 14, 27, 15),
                new Chunk(25, 13, 27, 8),
                new Chunk(27, 4, 35, 6),
                new Chunk(33, 7, 35, 7),
                new Chunk(29, 8, 35, 15),
                new Chunk(47, 1, 49, 1),
                new Chunk(37, 2, 49, 6),
                new Chunk(37, 12, 44, 8),
                new Chunk(46, 15, 49, 8),
                new Chunk(37, 13, 37, 15),
                new Chunk(38, 14, 39, 15),
                new Chunk(41, 14, 43, 15),
                new Chunk(44, 13, 44, 15),
                new Chunk(37, 7, 41, 7),
                new Chunk(47, 7, 49, 7),
            },

            beepers = new Beeper[]
            {
                new Beeper(2, 9),
                new Beeper(3, 9),
                new Beeper(5, 3),
                new Beeper(5, 9),
                new Beeper(6, 3),
                new Beeper(7, 3),
                new Beeper(12, 3),
                new Beeper(21, 1),
                new Beeper(22, 1),
                new Beeper(22, 13),
                new Beeper(23, 13),
                new Beeper(24, 1),
                new Beeper(24, 13),
                new Beeper(27, 1),
                new Beeper(28, 7),
                new Beeper(30, 7),
                new Beeper(31, 1),
                new Beeper(31, 7),
                new Beeper(34, 1),
                new Beeper(35, 1),
                new Beeper(38, 1),
                new Beeper(38, 13),
                new Beeper(42, 13),
                new Beeper(43, 1),
                new Beeper(43, 7),
                new Beeper(44, 7),
                new Beeper(45, 1),
                new Beeper(45, 7),
            }
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

            beepers = new Beeper[]
            {
                new Beeper(2, 1),
                new Beeper(4, 2),
                new Beeper(6, 2),
                new Beeper(10, 1),
                new Beeper(11, 1),
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

            wallChunks = new Chunk[]
            {
                new Chunk(0, 0, 14, 0),
                new Chunk(0, 1, 0, 3),
                new Chunk(3, 1, 3, 3),
                new Chunk(7, 1, 8, 3),
                new Chunk(13, 1, 14, 3),
            },

            walls = new Vector2[]
            {
                new Vector2(2, 2),
                new Vector2(2, 3),

                new Vector2(4, 1),
                new Vector2(4, 3),

                new Vector2(5, 1),

                new Vector2(6, 1),
                new Vector2(6, 3),

                new Vector2(9, 2),
                new Vector2(9, 3),

                new Vector2(11, 2),
                new Vector2(11, 3),

                new Vector2(12, 3),
            },

            beepers = new Beeper[]
            {
                new Beeper(14, 4)
            }
        };
        #endregion

        #region Pyramid
        public static Level Pyramid = new Level()
        {
            start = new Vector2(0, 0),
            size = new Vector2(5, 5),
            beeperCountStart = 99999,
            title = "pyramid",
        };
        #endregion
    }

    public struct Level
    {
        public Chunk[] wallChunks;
        public Beeper[] beepers;
        public Vector2[] walls;

        public int beeperCountStart;
        public Vector2 size, start;
        public string title;

        public bool isWall(Vector2 point)
        {
            if (walls != null)
                if (walls.Contains(point)) return true;

            if (wallChunks != null)
                foreach (Chunk chunk in wallChunks)
                    if (chunk.Contains(point)) return true;

            return false;
        }
    }

    public struct Beeper
    {
        public Beeper(Vector2 point, int count = 1)
        {
            this.point = point;
            this.count = count;
        }

        public Beeper(int x, int y, int count = 1)
        {
            this.point = new Vector2(x, y);
            this.count = count;
        }

        public Vector2 point;
        public int count;
    }

    public struct Chunk
    {
        public Vector2 a, b;

        public Chunk(int xMin, int yMin, int xMax, int yMax)
        {
            this.a = new Vector2(xMin, yMin);
            this.b = new Vector2(xMax, yMax);
        }

        public Chunk(Vector2 a, Vector2 b)
        {
            this.a = a;
            this.b = b;
        }

        public bool Contains(Vector2 point)
        {
            Vector2 a = new Vector2(Math.Min(this.a.X, this.b.X), Math.Min(this.a.Y, this.b.Y));
            Vector2 b = new Vector2(Math.Max(this.a.X, this.b.X), Math.Max(this.a.Y, this.b.Y));

            return
                point.X >= a.X && point.X <= b.X &&
                point.Y >= a.Y && point.Y <= b.Y;
        }
    }
}