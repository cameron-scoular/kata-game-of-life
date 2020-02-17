using System.Text.Json.Serialization;
using kata_game_of_life;
using kata_game_of_life.Boards;
using kata_game_of_life.Processors;
using kata_game_of_life.State;
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

            var expectedSerializedCellArray = JsonConvert.SerializeObject(emptyCellArray);
            
            var boardProcessor = new DefaultBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new TwoDimensionalBoard(emptyCellArray);
            
            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);
            
            Assert.Equal(expectedSerializedCellArray, JsonConvert.SerializeObject(initialGameState.Board.GetCellArray()));

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

            var expectedSerializedCellArray = JsonConvert.SerializeObject(emptyBoard);
            
            var boardProcessor = new DefaultBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new TwoDimensionalBoard(emptyBoard);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            var nextGameState = gameProcessor.Tick();
            
            Assert.Equal(expectedSerializedCellArray, JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));

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

            var expectedSerializedCellArray = JsonConvert.SerializeObject(cellArray);
            
            var boardProcessor = new DefaultBoardProcessor();    
            var gameProcessor = new GameProcessor(0);
            
            var board = new TwoDimensionalBoard(cellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            var nextGameState = gameProcessor.Tick();

            Assert.Equal(expectedSerializedCellArray, JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
        
        [Fact]
        public void GetNextBoard_GetsBoardWithOscillatingLine_GivenBoardWithLine()
        {
            var cellArray = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Alive), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Alive), new Cell(11, CellState.Dead), new Cell(12, CellState.Dead), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)},
                {new Cell(15, CellState.Alive), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
                {new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead), new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)}
            };
            
            var expectedCellArray = new [,] {
                {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)},
                {new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                {new Cell(10, CellState.Alive), new Cell(11, CellState.Alive), new Cell(12, CellState.Dead), new Cell(13, CellState.Dead), new Cell(14, CellState.Alive)},
                {new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
                {new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead), new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)}
            };
            
            var boardProcessor = new DefaultBoardProcessor();    
            var gameProcessor = new GameProcessor(0);
            
            var board = new TwoDimensionalBoard(cellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(expectedCellArray), JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }

        [Fact]
        public void GetNextBoard_GetsEmpty3DBoard_GivenEmpty3DBoard()
        {
            var emptyCellArray = new Cell[2, 2, 2]
            {
                {{new Cell(0, CellState.Dead),  new Cell(1, CellState.Dead)}, {new Cell(2, CellState.Dead),  new Cell(3, CellState.Dead)}},
                {{new Cell(4, CellState.Dead),  new Cell(5, CellState.Dead)}, {new Cell(6, CellState.Dead),  new Cell(7, CellState.Dead)}}
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(emptyCellArray);
            
            var boardProcessor = new DefaultBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new ThreeDimensionalBoard(emptyCellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);
            var nextGameState = gameProcessor.Tick();
            
            Assert.Equal(expectedSerializedCellArray, JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
        
        [Fact]
        public void GetNextBoard_Gets3DBoard_Given3DBoard()
        {
            var cellArray = new Cell[2, 2, 2]
            {
                {{new Cell(0, CellState.Alive),  new Cell(1, CellState.Alive)}, {new Cell(2, CellState.Dead),  new Cell(3, CellState.Dead)}},
                {{new Cell(4, CellState.Dead),  new Cell(5, CellState.Dead)}, {new Cell(6, CellState.Dead),  new Cell(7, CellState.Dead)}}
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(cellArray);
            
            var boardProcessor = new DefaultBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new ThreeDimensionalBoard(cellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);
            var nextGameState = gameProcessor.Tick();
            
            Assert.Equal(expectedSerializedCellArray, JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
        
        [Fact]
        public void GetNextBoard_GetsEmpty3DBoard_Given3DBoard()
        {
            var cellArray = new Cell[2, 2, 2]
            {
                {{new Cell(0, CellState.Alive),  new Cell(1, CellState.Dead)}, {new Cell(2, CellState.Dead),  new Cell(3, CellState.Dead)}},
                {{new Cell(4, CellState.Dead),  new Cell(5, CellState.Dead)}, {new Cell(6, CellState.Alive),  new Cell(7, CellState.Dead)}}
            };
            
            var emptyArray = new Cell[2, 2, 2]
            {
                {{new Cell(0, CellState.Dead),  new Cell(1, CellState.Dead)}, {new Cell(2, CellState.Dead),  new Cell(3, CellState.Dead)}},
                {{new Cell(4, CellState.Dead),  new Cell(5, CellState.Dead)}, {new Cell(6, CellState.Dead),  new Cell(7, CellState.Dead)}}
            };
            
            var boardProcessor = new DefaultBoardProcessor();
            var gameProcessor = new GameProcessor(0);
            
            var board = new ThreeDimensionalBoard(cellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);
            var nextGameState = gameProcessor.Tick();
            
            Assert.Equal(JsonConvert.SerializeObject(emptyArray), JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
    }
}