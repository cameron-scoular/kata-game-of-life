using System;
using System.Collections.Generic;

namespace kata_game_of_life
{
    public static class ArgumentParser
    {

        public static Arguments ParseArguments(string[] args)
        {
            var argumentObject = new Arguments()
            {
                LoadFileName = ParseStringArgument(args, "-l"),
                SaveFileName = ParseStringArgument(args, "-s"),
            };

            var loadFileExists = argumentObject.LoadFileName != null;
            argumentObject.DefaultDimensions = ParseDimensions(args, loadFileExists);

            return argumentObject;
        }

        private static List<int> ParseDimensions(string[] args, bool LoadFileExists)
        {
            var defaultOptionIndex = Array.FindIndex(args, x => x == "-d");
            if (defaultOptionIndex == -1 && !LoadFileExists) return new List<int>(){ 10, 10 };

            var dimensionList = new List<int>();
            var argIndex = defaultOptionIndex + 1;
            
            while(true){
                try
                {
                    dimensionList.Add(int.Parse(args[argIndex]));
                    argIndex++;
                }
                catch (Exception e)
                {
                    break;
                }
            }

            return dimensionList;
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