
using System;

namespace DungeonMaker
{
    class DungeonMaker
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Room[,] Dungeon { get; set; }
        public int Ods { get; set; }
        public int Seed {get;set;}
        private Random Rng{get;set;}
        public DungeonMaker(int x, int y, int ods,int seed)
        {
            this.Dungeon = new Room[x, y];
            this.Ods = ods;
            this.Rng = new Random(seed);
        }

        /// <summary>
        /// Function that will generate the dungeon
        /// </summary>
        /// <returns></returns>
        public Room[,] Build()
        {
            //1st pass calculate rooms
            for (int i = 0; i < this.Dungeon.GetLength(0); i++)
            {
                for (int j = 0; j < this.Dungeon.GetLength(1); j++)
                {
                    Room f = new Room(i, j);
                    BuildBasicRoom(f, this.Dungeon.GetLength(0), this.Dungeon.GetLength(1));
                    CheckSurroundingRooms(f, this.Dungeon.GetLength(0), this.Dungeon.GetLength(1));
                    fillInAdditionalWalls(f);
                    Dungeon[i, j] = f;
                }
            }
            //2nd Pass calculate for future rooms that have changed
            //@todo modify the logic so that a second pass shouldn't be needed anymore
            for (int i = 0; i < this.Dungeon.GetLength(0); i++)
            {
                for (int j = 0; j < this.Dungeon.GetLength(1); j++)
                {
                    CheckSurroundingRooms(this.Dungeon[i, j], this.Dungeon.GetLength(0), this.Dungeon.GetLength(1));
                }
            }
            return this.Dungeon;
        }

        /// <summary>
        /// this function will place walls in a room with a set of chances
        /// </summary>
        /// <param name="f">The room that needs walls placed in</param>
        private void fillInAdditionalWalls(Room f)
        {
            if (!f.NorthWall.Present)
            {
                CalculateWall(f.NorthWall);
            }
            if (!f.SouthWall.Present)
            {
                CalculateWall(f.SouthWall);
            }
            if (!f.EastWall.Present)
            {
                CalculateWall(f.EastWall);
            }
            if (!f.WestWall.Present)
            {
                CalculateWall(f.WestWall);
            }
        }

        /// <summary>
        /// Calculates the chance for a wall to be set or not
        /// </summary>
        /// <param name="w"></param>
        private void CalculateWall(Wall w)
        {
            
            int result = this.Rng.Next(this.Ods);
            w.Present = Ods - 1 == result;
            Console.WriteLine(result);
        }

        /// <summary>
        /// Checks previously handled room if tehr are adjacent walls we need to take into account
        /// </summary>
        /// <param name="f">The current room being handled</param>
        /// <param name="xLength">The number of rooms on the X-axis of the dungeon. @TODO Needs better implementation with the dungeon.</param>
        /// <param name="yLength">The number of rooms on the Y-axis of the dungeon. @TODO Needs better implementation with the dungeon.</param>
        private void CheckSurroundingRooms(Room f, int xLength, int yLength)
        {
            if (f.X != 0 && this.Dungeon[f.X - 1, f.Y].SouthWall.Present)
            {
                f.NorthWall.Present = true;
            }
            if (f.Y != 0 && this.Dungeon[f.X, f.Y - 1].EastWall.Present)
            {
                f.WestWall.Present = true;
            }
            if (f.Y + 1 != yLength && this.Dungeon[f.X, f.Y + 1] != null && this.Dungeon[f.X, f.Y + 1].WestWall.Present)
            {
                f.EastWall.Present = true;
            }
            if (f.X + 1 != xLength && this.Dungeon[f.X + 1, f.Y] != null && this.Dungeon[f.X + 1, f.Y].NorthWall.Present)
            {
                f.SouthWall.Present = true;
            }
        }

        /// <summary>
        /// Builds the room depending on the position it will follow general rules of a dungeon (e.g. outside walls)
        /// </summary>
        /// <param name="f">The current room being handled</param>
        /// <param name="xLength">The number of rooms on the X-axis of the dungeon. @TODO Needs better implementation with the dungeon.</param>
        /// <param name="yLength">The number of rooms on the Y-axis of the dungeon. @TODO Needs better implementation with the dungeon.</param>
        private void BuildBasicRoom(Room f, int xLength, int yLength)
        {
            //top row has a wall on the north side
            if (f.X == 0)
            {
                f.NorthWall.Present = true;
            }

            //left column has a wall on the east side
            if (f.Y == 0)
            {
                f.WestWall.Present = true;
            }
            //right column has a wall on the west side
            if (f.Y + 1 == yLength)
            {
                f.EastWall.Present = true;
            }
            //bottom row has a wall on the south side
            if (f.X + 1 == xLength)
            {
                f.SouthWall.Present = true;
            }
        }
    }
}