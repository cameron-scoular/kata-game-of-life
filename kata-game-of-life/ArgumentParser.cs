using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_game_of_life
{
    public static class ArgumentParser
    {

        public static Arguments ParseArguments(string[] args)
        {
            return new Arguments()
            {
                LoadFileName = ParseStringArgument(args, "-l"),
                SaveFileName = ParseStringArgument(args, "-s"),
                DefaultDimensions = Convert.ToInt32(ParseStringArgument(args, "-d"))
            };

        }

        private static string ParseStringArgument(string[] args, string optionString)
        {
            try
            {
                var optionIndex = Array.FindIndex(args, x => x == optionString);
                if (optionIndex == -1) return null;
                var optionArgumentIndex = optionIndex + 1;
                return args[optionArgumentIndex];
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }
        
    }
}