using kata_game_of_life;
using Newtonsoft.Json;
using Xunit;

namespace kata_game_of_life_tests
{
    public class GameProcessorShould
    {
        
        [Fact]
        public void StartNewGame_GetsEmptyBoard_GivenNewGameWithEmptyBoard()
        {
            
            var emptyCellArray = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Dead), new Cell(11, CellState.Dead), new Cell(12, CellState.Dead), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)},
                {new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
            };
            
            var boardProcessor = new BoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new DefaultBoard(emptyCellArray);
            
            var initialGameState = gameProcessor.StartNewGame(board, boardProcessor);
            
            Assert.Equal(JsonConvert.SerializeObject(emptyCellArray), JsonConvert.SerializeObject(initialGameState.Board.GetCellArray()));

        }
        
        [Fact]
        public void GetNextBoard_GetsEmptyBoard_GivenTickWithEmptyBoard()
        {
            
            var emptyBoard = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Dead), new Cell(11, CellState.Dead), new Cell(12, CellState.Dead), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)},
                {new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
            };
            
            var boardProcessor = new BoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new DefaultBoard(emptyBoard);

            var initialGameState = gameProcessor.StartNewGame(board, boardProcessor);
            var nextGameState = gameProcessor.Tick();
            
            Assert.Equal(JsonConvert.SerializeObject(emptyBoard), JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));

        }

        [Fact]
        public void GetNextBoard_GetsBoardWithSquare_GivenBoardWithSquare()
        {
            var cellArray = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Alive), new Cell(6, CellState.Alive), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Alive), new Cell(11, CellState.Alive), new Cell(12, CellState.Dead), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)},
                {new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
            };
            
            var boardProcessor = new BoardProcessor();    
            var gameProcessor = new GameProcessor(0);
            
            var board = new DefaultBoard(cellArray);

            var initialGameState = gameProcessor.StartNewGame(board, boardProcessor);
            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(cellArray), JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
        
        [Fact]
        public void GetNextBoard_GetsBoardWithOscillatingLine_GivenBoardWithLine()
        {
            var cellArray = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Dead), new Cell(6, CellState.Alive), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Dead), new Cell(11, CellState.Alive), new Cell(12, CellState.Dead), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)},
                {new Cell(15, CellState.Dead), new Cell(16, CellState.Alive), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
                {new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead), new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)}
            };
            
            var expectedCellArray = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Alive), new Cell(11, CellState.Alive), new Cell(12, CellState.Alive), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)},
                {new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
                {new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead), new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)}
            };
            
            var boardProcessor = new BoardProcessor();    
            var gameProcessor = new GameProcessor(0);
            
            var board = new DefaultBoard(cellArray);

            var initialGameState = gameProcessor.StartNewGame(board, boardProcessor);
            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(expectedCellArray), JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
        
        
    }
}