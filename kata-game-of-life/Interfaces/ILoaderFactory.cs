using System;
using System.Data;
using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface ILoaderFactory
    {
        IBoardLoader CreateBoardLoader(Type boardType);
        IBoardProcessorLoader CreateBoardProcessorLoader();

        INewGameLoader CreateNewGameLoader(Type boardType);
    }
}