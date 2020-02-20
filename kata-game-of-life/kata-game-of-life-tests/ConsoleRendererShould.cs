using kata_game_of_life.Boards;
using kata_game_of_life.GameRenderers;
using kata_game_of_life.State;
using Xunit;

namespace kata_game_of_life_tests
{
    public class ConsoleRendererShould
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
            
            var renderer = new TwoDimensionalConsoleRenderer();

            var renderString = renderer.GenerateBoardString(board);

            var expectedString = "---\n" +
                                 "ooo\n"+
                                 "..o\n" +
                                 "---\n";

            Assert.Equal(expectedString, renderString);

        }

        [Fact]
        public void GenerateBoardString_GetsCorrect3DBoardString_GivenGameState()
        {
            var cellArray = new [,,]
            {
                {
                    {new Cell(0, CellState.Alive), new Cell(1, CellState.Alive)},
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)},
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)}
                
                },
                {
                    {new Cell(0, CellState.Alive), new Cell(1, CellState.Alive)},
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)},
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Alive)}
                }
            };
            
            dynamic board = new ThreeDimensionalBoard(cellArray);
            
            var renderer = new ThreeDimensionalConsoleRenderer();

            var renderString = renderer.GenerateBoardString(board);

            var expectedString = "----\n" +
                                 ".. | oo | \n" +
                                 ".. | oo | \n" +
                                 "oo | oo | \n" +
                                 "----\n";

            Assert.Equal(expectedString, renderString);

        }
    }
}