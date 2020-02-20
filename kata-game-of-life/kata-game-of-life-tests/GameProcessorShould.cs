using System.Collections.Generic;
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

        public static IEnumerable<object[]> TwoDimensionalTestData => new List<object[]>
        {
            // Empty board to empty board
            new object[]
            {
                new[,]
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
                    }
                },
                new[,]
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
                    }
                }

            },
            // Square on board to square on board
            new object[]
            {
                new[,]
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
                    }
                },
                new[,]
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
                    }
                }
            },
            // Oscillating line on board
            new object[]
            {
                new[,]
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
                },
                new[,]
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
                }
            }

        };

        public static IEnumerable<object[]> ThreeDimensionalTestData => new List<object[]>
        {
            // Empty board to empty board
            new object[]
            {
                new[,,]
                {
                    {
                        {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                        {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                    },
                    {
                        {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                        {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                    }
                    
                },
                new[,,]
                {
                    {
                        {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                        {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                    },
                    {
                        {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                        {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                    }
                    
                }
            },
            new object[]
            {
                new[,,]
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
                },
                new[,,]
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
                    }
                }
            },
            new object[]
            {
                new [,,]
                {
                    {
                        {new Cell(0, CellState.Alive), new Cell(1, CellState.Dead)},
                        {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                    },
                    {
                        {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                        {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                    }
                },
                new [,,]
                {
                    {
                        {new Cell(0, CellState.Dead), new Cell(1, CellState.Dead)},
                        {new Cell(2, CellState.Dead), new Cell(3, CellState.Dead)}
                    },
                    {
                        {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                        {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                    }
                }
            }
        };
    

    [Theory]
        [MemberData(nameof(TwoDimensionalTestData))]
        public void Tick_Returned2DGameStateHasCorrectBoard_GivenInitialGameState(Cell[,] initialCellArray, Cell[,] expectedCellArray)
        {
            
            var boardProcessor = new DefaultBoardProcessor(new RuleSet("2333"));
            var gameProcessor = new GameProcessor(0);

            var board = new TwoDimensionalBoard(initialCellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            var nextGameState = gameProcessor.Tick();

            var actualCellArray = (Cell[,])nextGameState.Board.GetCellArray();
            
            Assert.Equal(JsonConvert.SerializeObject(expectedCellArray), JsonConvert.SerializeObject(actualCellArray));
        }
        
        [Theory]
        [MemberData(nameof(ThreeDimensionalTestData))]
        public void Tick_Returned3DGameStateHasCorrectBoard_GivenInitialGameState(Cell[,,] initialCellArray, Cell[,,] expectedCellArray)
        {
            var boardProcessor = new DefaultBoardProcessor(new RuleSet("2333"));
            var gameProcessor = new GameProcessor(0);

            var board = new ThreeDimensionalBoard(initialCellArray);

            var initialGameState = new GameState(board, boardProcessor);
            initialGameState = gameProcessor.StartNewGame(initialGameState);

            var nextGameState = gameProcessor.Tick();

            var actualCellArray = (Cell[,,])nextGameState.Board.GetCellArray();
            
            Assert.Equal(JsonConvert.SerializeObject(expectedCellArray), JsonConvert.SerializeObject(actualCellArray));
        }
        
    }

}