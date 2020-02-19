using System;
using System.Collections.Generic;
using kata_game_of_life.Boards;

namespace kata_game_of_life
{
    public static class Configuration
    {
        public static char CellAliveSymbol = 'o';
        public static char CellDeadSymbol = '.';
        public static uint TicksUntilSave = 10;
        public static int TickPeriod = 1000;
        public static int DefaultAlivePercent = 70;

        public static string DefaultSaveDirectory = "../../../Data/Saved Boards/";
        public static string DefaultNewDirectory = "../../../Data/New Boards/";

        public static Dictionary<int, Tuple<Type, string>> DefaultDimensionRulesetDictionary = new Dictionary<int, Tuple<Type, string>>()
        {
            {2, new Tuple<Type, string>(typeof(TwoDimensionalBoard), "2333")},
            {3, new Tuple<Type, string>(typeof(ThreeDimensionalBoard), "4555")},
        };
        
    }
}