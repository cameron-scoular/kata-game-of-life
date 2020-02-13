using System;
using System.IO;
using System.Linq;

namespace kata_game_of_life
{
    public class Local2DBoardPersistence : IBoardPersistence
    {

        public Cell[,] LoadBoardState(string path)
        {
            var rowStrings = File.ReadAllLines(path);

            var maxX = rowStrings[0].Length;
            var maxY = rowStrings.Length;

            var board = new Cell[maxX, maxY];
            
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    var coordinateCharacter = rowStrings[y][x];

                    var newCellState = coordinateCharacter == Constants.CellAliveRenderSymbol ? CellState.Alive : CellState.Dead;
                    var cellId = y * maxX + x;
                    board[maxX - x - 1, maxY - y - 1] = new Cell(cellId, newCellState);
                }
            }

            return board;
        }
        
        public void SaveBoardState(Cell[,] board, string path)
        {
            var maxX = board.GetLength(0);
            var maxY = board.GetLength(1);

            var rowStrings = Enumerable.Repeat(string.Empty, maxY).ToArray();

            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    var cellCharacter = board[x, y].CellState == CellState.Alive ? Constants.CellAliveRenderSymbol: Constants.CellDeadRenderSymbol;
                    rowStrings[y].Append(cellCharacter);
                }
            }
            
            File.WriteAllLines(path, rowStrings);
        }
        
    }
}