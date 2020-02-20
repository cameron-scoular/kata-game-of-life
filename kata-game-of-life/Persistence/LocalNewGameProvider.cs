using System;
using System.IO;
using System.Linq;
using kata_game_of_life.Boards;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life.Persistence
{
    public class LocalNewGameProvider : INewGameProvider
    {

        public GameState LoadNewGame(Arguments arguments)
        {
            
            if (LoadingArgumentsAreNotSpecified(arguments))
            {
                return LoadDefaultNewGameState(arguments);
            }

            return LoadNewGameFile(arguments.LoadFileName);
        }

        private static bool LoadingArgumentsAreNotSpecified(Arguments arguments)
        {
            return arguments.DefaultDimensions.Count > 0 || arguments.LoadFileName == null || arguments.LoadFileName == string.Empty;
        }

        private GameState LoadNewGameFile(string fileName)
        {
            
            var cells = LoadNew2DCellArray(fileName);
            var board = new TwoDimensionalBoard(cells);

            var ruleSet = Configuration.DefaultRuleSets.First(r => r.Key == board.GetDimensions().Count).Value;
            
            return new GameState(board, new DefaultBoardProcessor(ruleSet));
        }

        private GameState LoadDefaultNewGameState(Arguments arguments)
        {
            var boardRules = Configuration.DefaultRuleSets.First(r => r.Key == arguments.DefaultDimensions.Count);
            var boardType = Configuration.DefaultBoards.First(t => t.Key == arguments.DefaultDimensions.Count).Value;
            var ruleSet = boardRules.Value;

            var board = (IBoard)Activator.CreateInstance(boardType, arguments.DefaultDimensions);
            
            return new GameState(board, new DefaultBoardProcessor(ruleSet));
        }
        
        private static Cell[,] LoadNew2DCellArray(string fileName)
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

                    var newCellState = coordinateCharacter == Configuration.CellAliveSymbol ? CellState.Alive : CellState.Dead;
                    var cellId = y * maxX + x;
                    board[maxX - x - 1, maxY - y - 1] = new Cell(cellId, newCellState);
                }
            }

            return board;
        }

    }
}