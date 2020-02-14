using kata_game_of_life;
using kata_game_of_life.Boards;
using kata_game_of_life.GameRenderers;
using kata_game_of_life.Processors;
using kata_game_of_life.State;
using Xunit;

namespace kata_game_of_life_tests
{
    public class Game2DConsoleRendererShould
    {

        [Fact]
        public void GenerateBoardString_GetsCorrectBoardString_GivenGameState()
        {

            var cellArray = new [,]
            {
                {new Cell(0, CellState.Alive), new Cell(1, CellState.Alive)},
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)},
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)}
            };
            
            var board = new TwoDimensionalBoard(cellArray);
            var gameState = new GameState(board, new BoardProcessor());
            
            var renderer = new TwoDimensionalConsoleRenderer();

            var renderString = renderer.GenerateBoardString(gameState);

            var expectedString = "ooo\n" +
                                 "..o\n";
                            
            
            Assert.Equal(expectedString, renderString);

        }
    }
}