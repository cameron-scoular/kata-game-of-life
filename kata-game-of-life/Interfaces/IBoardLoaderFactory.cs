using System;

namespace kata_game_of_life.Interfaces
{
    public interface IBoardLoaderFactory
    {
        Func<object, IBoard> CreateBoardLoader(Type boardType);
        Func<int, IBoardProcessor> CreateBoardProcessorLoader(Type boardProcessorType);
    }
}