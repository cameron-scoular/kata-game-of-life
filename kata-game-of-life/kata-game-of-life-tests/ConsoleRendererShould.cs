using kata_game_of_life.Board;
using kata_game_of_life.Processors;
using kata_game_of_life.Renderer;
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
            
            var board = new TwoDimensionalBoard(cellArray);
            
            var gameState = new GameState(board, new DefaultBoardProcessor(new RuleSet("2333")));
            
            var renderer = new TwoDimensionalConsoleRenderer();

            var renderString = renderer.GenerateBoardString(gameState);

            var expectedString = "ooo\n" +
                                 "..o\n";

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
            
            var board = new ThreeDimensionalBoard(cellArray);
            
            var renderer = new ThreeDimensionalConsoleRenderer();
            
            var gameState = new GameState(board, new DefaultBoardProcessor(new RuleSet("4555")));

            var renderString = renderer.GenerateBoardString(gameState);

            var expectedString = "----------\n" +
                                 ".. | oo | \n" +
                                 ".. | oo | \n" +
                                 "oo | oo | \n" +
                                 "----------\n";

            Assert.Equal(expectedString, renderString);

        }
    }
}