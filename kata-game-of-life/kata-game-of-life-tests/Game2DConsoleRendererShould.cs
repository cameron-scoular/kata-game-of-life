using kata_game_of_life.Boards;
using kata_game_of_life.GameRenderers;
using kata_game_of_life.State;
using Xunit;

namespace kata_game_of_life_tests
{
    public class Game2DConsoleRendererShould
    {

        [Fact]
        public void GenerateBoardString_GetsCorrect2DBoardString_GivenGameState()
        {

            var cellArray = new [,]
            {
                {new Cell(0, CellState.Alive), new Cell(1, CellState.Alive)},
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)},
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)}
            };
            
            dynamic board = new TwoDimensionalBoard(cellArray);
            
            var renderer = new ConsoleRenderer();

            var renderString = renderer.GenerateBoardString(board);

            var expectedString = "---\n" +
                                 "ooo\n"+
                                 "..o\n" +
                                 "---\n";

            Assert.Equal(expectedString, renderString);

        }
    }
}