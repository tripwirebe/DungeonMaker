namespace DungeonMaker
{
    public class Room
    {
        public Wall EastWall;
        public Wall WestWall;
        public Wall SouthWall;
        public Wall NorthWall;
        public int X { get; set; }
        public int Y { get; set; }
        public Room(int x, int y)
        {
            this.EastWall = new Wall();
            this.WestWall = new Wall();
            this.NorthWall = new Wall();
            this.SouthWall = new Wall();
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            string result = string.Empty;
            result += (this.NorthWall.Present) ? "N" : string.Empty;
            result += (this.EastWall.Present) ? "E" : string.Empty;
            result += (this.SouthWall.Present) ? "S" : string.Empty;
            result += (this.WestWall.Present) ? "W" : string.Empty;
            return result;
        }
    }
}