using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (arguments.DefaultDimensions.Count > 0 || arguments.LoadFileName == null || arguments.LoadFileName == string.Empty)
            {
                return GetRandomNewGameState(arguments);
            }

            return LoadNewGameFile(arguments.LoadFileName);
        }

        private GameState LoadNewGameFile(string fileName)
        {
            var cells = LoadNew2DCellArray(fileName);
            var board = new TwoDimensionalBoard(cells);
            
            var ruleSet = Configuration.DefaultDimensionRulesetDictionary[2].Item2;
            
            return new GameState(board, new DefaultBoardProcessor(ruleSet));
        }

        private GameState GetRandomNewGameState(Arguments arguments)
        {
            var boardRules = Configuration.DefaultDimensionRulesetDictionary[arguments.DefaultDimensions.Count];
            var boardType = boardRules.Item1;
            var ruleSet = boardRules.Item2;

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