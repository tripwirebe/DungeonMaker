
using System;

namespace DungeonMaker
{
    class DungeonMaker
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Room[,] Dungeon { get; set; }
        public int Ods { get; set; }
        public DungeonMaker(int x, int y, int ods)
        {
            this.Dungeon = new Room[x, y];
            this.Ods = ods;
        }

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
            for (int i = 0; i < this.Dungeon.GetLength(0); i++)
            {
                for (int j = 0; j < this.Dungeon.GetLength(1); j++)
                {
                    CheckSurroundingRooms(this.Dungeon[i,j], this.Dungeon.GetLength(0), this.Dungeon.GetLength(1));
                }
            }
            return this.Dungeon;
        }

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

        private void CalculateWall(Wall w)
        {
            Random r = new Random();
            int result = r.Next(this.Ods);
            w.Present = Ods - 1 == result;
            Console.WriteLine(result);
        }

        private void GenerateWall(Wall northWall)
        {
            throw new NotImplementedException();
        }

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
            if (f.Y + 1 != yLength && this.Dungeon[f.X, f.Y + 1] != null &&  this.Dungeon[f.X, f.Y + 1].WestWall.Present)
            {
                f.EastWall.Present = true;
            }
            if (f.X + 1 != xLength &&this.Dungeon[f.X + 1, f.Y] != null && this.Dungeon[f.X + 1, f.Y].NorthWall.Present)
            {
                f.SouthWall.Present = true;
            }
        }

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