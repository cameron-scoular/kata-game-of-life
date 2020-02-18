using System;
using System.Collections.Generic;
using kata_game_of_life.Boards;
using kata_game_of_life.Interfaces;

namespace kata_game_of_life
{
    public static class Configuration
    {
        public static char CellAliveRenderSymbol = 'o';
        public static char CellDeadRenderSymbol = '.';
        public static uint TicksUntilSave = 10;
        public static int TickPeriod = 1000;

        public static string DefaultSaveDirectory = "../../../Data/Saved Boards/";
        public static string DefaultNewDirectory = "../../../Data/New Boards/";

        public static Dictionary<int, Tuple<IBoard, string>> DimensionDefaultRulesetDictionary = new Dictionary<int, Tuple<IBoard, string>>()
        {
            {2, new Tuple<IBoard, string>(new TwoDimensionalBoard(), "2333")},
            {3, new Tuple<IBoard, string>(new ThreeDimensionalBoard(), "4555")},
        };
        
    }
}