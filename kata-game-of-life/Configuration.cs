using System.Net.Http;

namespace kata_game_of_life
{
    public static class Configuration
    {
        public static char CellAliveRenderSymbol = 'o';
        public static char CellDeadRenderSymbol = '.';
        public static uint TicksUntilSave = 10;
        public static int TickPeriod = 1000;
        public static string DefaultSaveDirectory = string.Format("{0}Saved Boards", System.AppDomain.CurrentDomain.BaseDirectory);
    }
}