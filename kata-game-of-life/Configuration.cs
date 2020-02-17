using System.Collections.Generic;

namespace kata_game_of_life
{
    public static class Configuration
    {
        public static char CellAliveRenderSymbol = 'o';
        public static char CellDeadRenderSymbol = '.';
        public static uint TicksUntilSave = 10;
        public static int TickPeriod = 1000;
        public static int ConsoleLineBreakerLength = 50;

        public static string DefaultSaveDirectory = "../../../Data/Saved Boards/";
        public static string DefaultNewDirectory = "../../../Data/New Boards/";
        
        public static Dictionary<int, string> DefaultDimensionGameDictionary = new Dictionary<int, string>()
        {
            {2, "default2DBoard.nlife"},
        };
        
    }
}