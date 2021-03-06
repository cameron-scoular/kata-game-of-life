using System;
using System.Collections.Generic;
using kata_game_of_life.Board;
using kata_game_of_life.State;

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
        
        public static List<int> DefaultDimensions = new List<int>() { 10, 10 };

        public static Dictionary<int, RuleSet> DefaultRuleSets = new Dictionary<int, RuleSet>()
        {
            {2, new RuleSet("2333")},
            {3, new RuleSet("4555")}
        };
        
        public static Dictionary<int, Type> DefaultBoards = new Dictionary<int, Type>()
        {
            {2, typeof(TwoDimensionalBoard)},
            {3, typeof(ThreeDimensionalBoard)}
        };
        
    }
}