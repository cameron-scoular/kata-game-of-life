using System.Net.Http;

namespace kata_game_of_life
{
    public static class Configuration
    {
        public static char CellAliveRenderSymbol = 'o';
        public static char CellDeadRenderSymbol = '.';
        public static uint TicksUntilSave = 10;
        public static int TickPeriod = 1000;
        //public static string DefaultSaveDirectory = $"{System.AppDomain.CurrentDomain.BaseDirectory}/../../../Data/Saved Boards";
        public static string DefaultSaveDirectory = "../../../Data/Saved Boards/";
        public static string DefaultNewDirectory = "../../../Data/New Boards/";
    }
}