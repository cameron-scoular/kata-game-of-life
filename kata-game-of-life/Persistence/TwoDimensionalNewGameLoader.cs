using System;
using System.IO;
using System.Linq;
using kata_game_of_life.Board;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life.Persistence
{
    public class TwoDimensionalNewGameLoader : INewGameLoader
    {
        
        public GameState LoadNewGame(string fileName)
        {
            fileName = NewGameProvider.AddFileNameExtension(fileName);
            var cells = LoadNew2DCellArray(fileName);
            var board = new TwoDimensionalBoard(cells);

            var ruleSet = Configuration.DefaultRuleSets.First(r => r.Key == board.GetDimensions().Count).Value;
            
            return new GameState(board, new DefaultBoardProcessor(ruleSet));
        }

        
        private static Cell[,] LoadNew2DCellArray(string fileName)
        {
            var path = $"{Configuration.DefaultNewDirectory}{fileName}";
            
            var rowStrings = File.ReadAllLines(path);
            rowStrings = rowStrings.Skip(1).ToArray();

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