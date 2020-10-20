using System;

namespace DungeonMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = 500;
            int x = 5;
            int y = 5;
            int odds = 10;
            DungeonMaker dungeonMaker = new DungeonMaker(x,y,odds,seed);
            Room [,] dungeon = dungeonMaker.Build();
            PrintDungeon(dungeon);
        }
        public static void PrintDungeon(Room[,]dungeon){
            for(int i = 0; i < dungeon.GetLength(0);i++){
                string result = string.Empty;
                for(int j = 0; j < dungeon.GetLength(1);j++){
                    result += $"{dungeon[i,j]}";
                }
                Console.WriteLine(result);
            }
        }
    }
}