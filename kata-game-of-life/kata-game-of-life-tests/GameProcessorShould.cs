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
            
            var emptyBoard = new [,] {
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            
            var boardProcessor = new WrappingBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var initialGameState = gameProcessor.StartNewGame(emptyBoard, boardProcessor);
            
            Assert.Equal(JsonConvert.SerializeObject(emptyBoard), JsonConvert.SerializeObject(initialGameState.Board));

        }
        
        [Fact]
        public void GetNextBoard_GetsEmptyBoard_GivenTickWithEmptyBoard()
        {
            
            var emptyBoard = new [,] {
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            
            var boardProcessor = new WrappingBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var initialGameState = gameProcessor.StartNewGame(emptyBoard, boardProcessor);
            var nextGameState = gameProcessor.Tick();
            
            Assert.Equal(JsonConvert.SerializeObject(emptyBoard), JsonConvert.SerializeObject(nextGameState.Board));

        }

        [Fact]
        public void GetNextBoard_GetsBoardWithSquare_GivenBoardWithSquare()
        {
            var initialBoard = new [,] {
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            
            var boardProcessor = new WrappingBoardProcessor();    
            var gameProcessor = new GameProcessor(0);

            var initialGameState = gameProcessor.StartNewGame(initialBoard, boardProcessor);
            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(initialBoard), JsonConvert.SerializeObject(nextGameState.Board));
        }
        
        [Fact]
        public void GetNextBoard_GetsBoardWithOscillatingLine_GivenBoardWithLine()
        {
            var initialBoard = new [,] {
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            
            var expectedBoard = new [,] {
                {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
            };
            
            var boardProcessor = new WrappingBoardProcessor();    
            var gameProcessor = new GameProcessor(0);

            var initialGameState = gameProcessor.StartNewGame(initialBoard, boardProcessor);
            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(expectedBoard), JsonConvert.SerializeObject(nextGameState.Board));
        }
        
        
    }
}