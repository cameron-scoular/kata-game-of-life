using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_game_of_life
{
    public static class ArgumentParser
    {

        public static Arguments ParseArguments(string[] args)
        {
            var dimensions = int.Parse(args[0]);
            
            return new Arguments()
            {
                Dimensions = dimensions,
                LoadFileName = ParseStringArgument(args, "-l"),
                SaveFileName = ParseStringArgument(args, "-s"),
                LoadResourceName = ParseStringArgument(args, "-r")
            };

        }

        private static string ParseStringArgument(string[] args, string optionString)
        {
            try
            {
                var optionIndex = Array.FindIndex(args, x => x == optionString);
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