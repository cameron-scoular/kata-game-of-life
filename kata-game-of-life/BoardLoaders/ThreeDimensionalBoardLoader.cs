using kata_game_of_life.Board;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.BoardLoaders
{
    public class ThreeDimensionalBoardLoader : IBoardLoader
    {
        public IBoard LoadBoard(dynamic cellArrayState)
        {
            return new ThreeDimensionalBoard((Cell[,,])cellArrayState.ToObject<Cell[,,]>());
        }
    }
}