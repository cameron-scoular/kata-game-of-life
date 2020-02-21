using kata_game_of_life.Board;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.BoardLoaders
{
    public class TwoDimensionalBoardLoader: IBoardLoader
    {
        public IBoard LoadBoard(dynamic cellArrayState)
        {
            return new TwoDimensionalBoard((Cell[,])cellArrayState.ToObject<Cell[,]>());
        }
    }
}