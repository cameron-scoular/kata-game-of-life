using System;
using System.Data;

namespace kata_game_of_life.Interfaces
{
    public interface IBoardLoaderFactory
    {
        Func<object, IBoard> CreateBoardLoader(Type boardType);
        Func<RuleSet, IBoardProcessor> CreateBoardProcessorLoader(Type boardProcessorType);
    }
}