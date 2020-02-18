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

            var emptyCellArray = new[,]
            {
                {
                    new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead),
                    new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)
                },
                {
                    new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead),
                    new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)
                },
                {
                    new Cell(10, CellState.Dead), new Cell(11, CellState.Dead), new Cell(12, CellState.Dead),
                    new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)
                },
                {
                    new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead),
                    new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)
                },
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(emptyCellArray);

            var boardProcessor = new DefaultBoardProcessor("2333");
            var gameProcessor = new GameProcessor(0);

            var board = new TwoDimensionalBoard(emptyCellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            Assert.Equal(expectedSerializedCellArray,
                JsonConvert.SerializeObject(initialGameState.Board.GetCellArray()));

        }

        [Fact]
        public void GetNextBoard_GetsEmptyBoard_GivenTickWithEmptyBoard()
        {

            var emptyBoard = new[,]
            {
                {
                    new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead),
                    new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)
                },
                {
                    new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead),
                    new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)
                },
                {
                    new Cell(10, CellState.Dead), new Cell(11, CellState.Dead), new Cell(12, CellState.Dead),
                    new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)
                },
                {
                    new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead),
                    new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)
                },
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(emptyBoard);

            var boardProcessor = new DefaultBoardProcessor("2333");
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
            var cellArray = new[,]
            {
                {
                    new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead),
                    new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)
                },
                {
                    new Cell(5, CellState.Alive), new Cell(6, CellState.Alive), new Cell(7, CellState.Dead),
                    new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)
                },
                {
                    new Cell(10, CellState.Alive), new Cell(11, CellState.Alive), new Cell(12, CellState.Dead),
                    new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)
                },
                {
                    new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead),
                    new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)
                },
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(cellArray);

            var boardProcessor = new DefaultBoardProcessor("2333");
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
            var cellArray = new[,]
            {
                {
                    new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead),
                    new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)
                },
                {
                    new Cell(5, CellState.Alive), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead),
                    new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)
                },
                {
                    new Cell(10, CellState.Alive), new Cell(11, CellState.Dead), new Cell(12, CellState.Dead),
                    new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)
                },
                {
                    new Cell(15, CellState.Alive), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead),
                    new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)
                },
                {
                    new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead),
                    new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)
                }
            };

            var expectedCellArray = new[,]
            {
                {
                    new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead),
                    new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)
                },
                {
                    new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Dead),
                    new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)
                },
                {
                    new Cell(10, CellState.Alive), new Cell(11, CellState.Alive), new Cell(12, CellState.Dead),
                    new Cell(13, CellState.Dead), new Cell(14, CellState.Alive)
                },
                {
                    new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Dead),
                    new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)
                },
                {
                    new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead),
                    new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)
                }
            };

            var boardProcessor = new DefaultBoardProcessor("2333");
            var gameProcessor = new GameProcessor(0);

            var board = new TwoDimensionalBoard(cellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(expectedCellArray),
                JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }

        [Fact]
        public void GetNextBoard_GetsEmpty3DBoard_GivenEmpty3DBoard()
        {
            var emptyCellArray = new Cell[2, 2, 2]
            {
                {
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                },
                {
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                }
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(emptyCellArray);

            var boardProcessor = new DefaultBoardProcessor("4555");
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
            var cellArray = new[,,]
            {
                {
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)},
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)},
                    {new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)},
                    {new Cell(10, CellState.Dead), new Cell(11, CellState.Dead)},
                    {new Cell(12, CellState.Dead), new Cell(13, CellState.Dead)},
                    {new Cell(14, CellState.Dead), new Cell(15, CellState.Dead)},
                },
                {
                    {new Cell(16, CellState.Dead), new Cell(17, CellState.Dead)},
                    {new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
                    {new Cell(20, CellState.Dead), new Cell(21, CellState.Alive)},
                    {new Cell(22, CellState.Alive), new Cell(23, CellState.Dead)},
                    {new Cell(24, CellState.Dead), new Cell(25, CellState.Alive)},
                    {new Cell(26, CellState.Alive), new Cell(27, CellState.Dead)},
                    {new Cell(28, CellState.Dead), new Cell(29, CellState.Dead)},
                    {new Cell(30, CellState.Dead), new Cell(31, CellState.Dead)},
                },
                {
                    {new Cell(32, CellState.Dead), new Cell(33, CellState.Dead)},
                    {new Cell(34, CellState.Dead), new Cell(35, CellState.Dead)},
                    {new Cell(36, CellState.Dead), new Cell(37, CellState.Dead)},
                    {new Cell(38, CellState.Dead), new Cell(39, CellState.Dead)},
                    {new Cell(40, CellState.Dead), new Cell(41, CellState.Dead)},
                    {new Cell(42, CellState.Dead), new Cell(43, CellState.Dead)},
                    {new Cell(44, CellState.Dead), new Cell(45, CellState.Dead)},
                    {new Cell(46, CellState.Dead), new Cell(47, CellState.Dead)},
                },
            };

            var expectedCellArray = new[,,]
            {
                {
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)},
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Alive), new Cell(7, CellState.Dead)},
                    {new Cell(8, CellState.Dead), new Cell(9, CellState.Alive)},
                    {new Cell(10, CellState.Dead), new Cell(11, CellState.Dead)},
                    {new Cell(12, CellState.Dead), new Cell(13, CellState.Dead)},
                    {new Cell(14, CellState.Dead), new Cell(15, CellState.Dead)},
                },
                {
                    {new Cell(16, CellState.Dead), new Cell(17, CellState.Dead)},
                    {new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)},
                    {new Cell(20, CellState.Dead), new Cell(21, CellState.Dead)},
                    {new Cell(22, CellState.Alive), new Cell(23, CellState.Dead)},
                    {new Cell(24, CellState.Dead), new Cell(25, CellState.Alive)},
                    {new Cell(26, CellState.Dead), new Cell(27, CellState.Dead)},
                    {new Cell(28, CellState.Dead), new Cell(29, CellState.Dead)},
                    {new Cell(30, CellState.Dead), new Cell(31, CellState.Dead)},
                },
                {
                    {new Cell(32, CellState.Dead), new Cell(33, CellState.Dead)},
                    {new Cell(34, CellState.Dead), new Cell(35, CellState.Dead)},
                    {new Cell(36, CellState.Dead), new Cell(37, CellState.Dead)},
                    {new Cell(38, CellState.Alive), new Cell(39, CellState.Dead)},
                    {new Cell(40, CellState.Dead), new Cell(41, CellState.Alive)},
                    {new Cell(42, CellState.Dead), new Cell(43, CellState.Dead)},
                    {new Cell(44, CellState.Dead), new Cell(45, CellState.Dead)},
                    {new Cell(46, CellState.Dead), new Cell(47, CellState.Dead)},
                },
            };

            var expectedSerializedCellArray = JsonConvert.SerializeObject(expectedCellArray);

            var boardProcessor = new DefaultBoardProcessor("4555");
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
                {
                    {new Cell(0, CellState.Alive), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                },
                {
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                }
            };

            var emptyArray = new Cell[2, 2, 2]
            {
                {
                    {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                },
                {
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                }
            };

            var boardProcessor = new DefaultBoardProcessor("4555");
            var gameProcessor = new GameProcessor(0);

            var board = new ThreeDimensionalBoard(cellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);
            var nextGameState = gameProcessor.Tick();

            Assert.Equal(JsonConvert.SerializeObject(emptyArray),
                JsonConvert.SerializeObject(nextGameState.Board.GetCellArray()));
        }
    }

}