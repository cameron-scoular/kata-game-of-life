using System;
using System.IO;
using kata_game_of_life.Boards;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life.Persistence
{
    public class LocalNewGameLoader : INewGameLoader
    {

        public GameState LoadNewGame(Arguments arguments)
        {
            if (arguments.DefaultDimensions != 0 || arguments.LoadFileName == null || arguments.LoadFileName == string.Empty)
            {
                return GetDefaultNewGameState(arguments);
            }

            return LoadNewGameFile(arguments.LoadFileName);
        }
        
        private GameState LoadNewGameFile(string fileName)
        {
            var cells = LoadNew2DCellArray(fileName);
            var board = new TwoDimensionalBoard(cells);
            
            return new GameState(board, new DefaultBoardProcessor());
        }

        public GameState GetDefaultNewGameState(Arguments arguments)
        {
            switch (arguments.DefaultDimensions)
            {
                case 2:
                    return LoadNewGameFile(Configuration.DefaultDimensionGameDictionary[2]);
                case 3:
                    return LoadDefault3DGame();
                default:
                    throw new NotImplementedException($"Default game is not supported for {arguments.DefaultDimensions} dimensions");
            }
        }

        public static Cell[,] LoadNew2DCellArray(string fileName)
        {
            var path = $"{Configuration.DefaultNewDirectory}{fileName}";
            
            var rowStrings = File.ReadAllLines(path);

            var maxX = rowStrings[0].Length;
            var maxY = rowStrings.Length;

            var board = new Cell[maxX, maxY];
            
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    var coordinateCharacter = rowStrings[y][x];

                    var newCellState = coordinateCharacter == Configuration.CellAliveRenderSymbol ? CellState.Alive : CellState.Dead;
                    var cellId = y * maxX + x;
                    board[maxX - x - 1, maxY - y - 1] = new Cell(cellId, newCellState);
                }
            }

            return board;
        }

        public static GameState LoadDefault3DGame()
        {
            var cells =  new Cell[2, 2, 2]
            {
                {
                    {new Cell(0, CellState.Alive), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Alive), new Cell(3, CellState.Dead)}
                },
                {
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                }
            };
            var board = new ThreeDimensionalBoard(cells);
            return new GameState(board, new DefaultBoardProcessor());
        }

        public static Cell[,] LoadDefault2dBoard()
        {
            return new[,]
            {
                {
                    new Cell(0, CellState.Dead), new Cell(1, CellState.Dead), new Cell(2, CellState.Dead), new Cell(3, CellState.Dead), new Cell(4, CellState.Dead)
                },
                {
                    new Cell(5, CellState.Dead), new Cell(6, CellState.Dead), new Cell(7, CellState.Alive), new Cell(8, CellState.Dead), new Cell(9, CellState.Dead)
                },
                {
                    new Cell(10, CellState.Dead), new Cell(11, CellState.Dead), new Cell(12, CellState.Alive), new Cell(13, CellState.Dead), new Cell(14, CellState.Dead)
                },
                {
                    new Cell(15, CellState.Dead), new Cell(16, CellState.Dead), new Cell(17, CellState.Alive), new Cell(18, CellState.Dead), new Cell(19, CellState.Dead)
                },
                {
                    new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead), new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)
                },
            };
        }
    }
}