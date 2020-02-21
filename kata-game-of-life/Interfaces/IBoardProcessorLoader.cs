using System;
using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface IBoardProcessorLoader
    {
        IBoardProcessor LoadBoardProcessor(RuleSet ruleSet, Type boardLoaderProcessorType);
    }
}