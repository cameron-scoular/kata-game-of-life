using System;
using System.IO;
using System.Linq;
using kata_game_of_life.Board;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life.BoardLoaders
{
    public class ThreeDimensionalNewGameLoader : INewGameLoader
    {
        public GameState LoadNewGame(string fileName)
        {
            fileName = NewGameProvider.AddFileNameExtension(fileName);
            var cells = LoadNew3DCellArray(fileName);
            
            var board = new ThreeDimensionalBoard(cells);

            var ruleSet = Configuration.DefaultRuleSets.First(r => r.Key == board.GetDimensions().Count).Value;
            
            return new GameState(board, new DefaultBoardProcessor(ruleSet));        
        }

        private Cell[,,] LoadNew3DCellArray(string fileName)
        {
            var path = $"{Configuration.DefaultNewDirectory}{fileName}";
            
            var rowStrings = File.ReadAllLines(path);
            rowStrings = rowStrings.Skip(1).ToArray();

            var maxX = rowStrings[0].Length;
            var maxZ = rowStrings.Count(r => r.Contains(",")) + 1;
            var maxY = rowStrings.Count(r => !r.Contains(",")) / maxZ;

            var board = new Cell[maxX, maxY, maxZ];

            for (var z = 0; z < maxZ; z++)
            {
                for (var y = 0; y < maxY; y++)
                {
                    for (var x = 0; x < maxX; x++)
                    {
                        var coordinateCharacter = rowStrings[y + ( maxY + 1 ) * z][x];

                        var newCellState = coordinateCharacter == Configuration.CellAliveSymbol ? CellState.Alive : CellState.Dead;
                        var cellId = z * maxY * maxX + y * maxX + x;
                        board[maxX - x - 1, maxY - y - 1, maxZ - z - 1] = new Cell(cellId, newCellState); 
                    }
                }
            }

            return board;
        }
    }
}