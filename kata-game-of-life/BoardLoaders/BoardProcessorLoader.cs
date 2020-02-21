using System;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.BoardLoaders
{
    public class BoardProcessorLoader : IBoardProcessorLoader
    {
        public IBoardProcessor LoadBoardProcessor(RuleSet ruleSet, Type boardLoaderProcessorType)
        {
            if (typeof(IBoardProcessor).IsAssignableFrom(boardLoaderProcessorType))
            {
                return (IBoardProcessor)Activator.CreateInstance(boardLoaderProcessorType, ruleSet);
            }
            
            throw new ArgumentException("Loaded board processor type is not valid");
        }
    }
}