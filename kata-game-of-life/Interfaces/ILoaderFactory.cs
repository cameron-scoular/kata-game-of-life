using System;

namespace kata_game_of_life.Interfaces
{
    public interface ILoaderFactory
    {
        IBoardLoader CreateBoardLoader(Type boardType);
        IBoardProcessorLoader CreateBoardProcessorLoader();

        INewGameLoader CreateNewGameLoader(Type boardType);
    }
}