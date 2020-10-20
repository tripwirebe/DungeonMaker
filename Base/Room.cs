namespace DungeonMaker
{
    public class Room
    {
        /// <summary>
        /// EastWall of the room
        /// </summary>
        public Wall EastWall;
        /// <summary>
        /// WestWall of the room
        /// </summary>
        public Wall WestWall;
        /// <summary>
        /// Soutwall of the room
        /// </summary>
        /// <value></value>
        public Wall SouthWall{get;set;}
        /// <summary>
        /// Northwall of the room
        /// </summary>
        public Wall NorthWall{get;set;}
        /// <summary>
        /// X location of the room
        /// </summary>
        /// <value></value>
        public int X { get; set; }
        /// <summary>
        /// Y location of the room
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// string representation of a door
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = string.Empty;
            result += (this.NorthWall.Present) ? "N" : string.Empty;
            result += (this.EastWall.Present) ? "E" : string.Empty;
            result += (this.SouthWall.Present) ? "S" : string.Empty;
            result += (this.WestWall.Present) ? "W" : string.Empty;
            result += "\t";
            return result;
        }
        /// <summary>
        /// the room has 4 walls so is closed if there are no doors present
        /// </summary>
        /// <returns></returns>
        public bool RoomClosed(){
            return this.NorthWall.Present && this.EastWall.Present && this.SouthWall.Present && this.WestWall.Present;
        }
        /// <summary>
        /// diplays that there is a door present in this room
        /// </summary>
        /// <returns></returns>
        public bool HasDoor(){
            return this.NorthWall.Door && this.EastWall.Door && this.SouthWall.Door && this.WestWall.Door;
        }
    }
}