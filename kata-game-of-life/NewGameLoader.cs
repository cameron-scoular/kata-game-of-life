using System.IO;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    public static class NewGameLoader
    {
        public static Cell[,] LoadNew2dCellArray(string path)
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

                    var newCellState = coordinateCharacter == Configuration.CellAliveRenderSymbol ? CellState.Alive : CellState.Dead;
                    var cellId = y * maxX + x;
                    board[maxX - x - 1, maxY - y - 1] = new Cell(cellId, newCellState);
                }
            }

            return board;
        }

        public static Cell[,,] LoadDefault3dBoard()
        {
            return new Cell[2, 2, 2]
            {
                {
                    {new Cell(0, CellState.Alive), new Cell(1, CellState.Dead)},
                    {new Cell(2, CellState.Dead), new Cell(3, CellState.Alive)}
                },
                {
                    {new Cell(4, CellState.Dead), new Cell(5, CellState.Dead)},
                    {new Cell(6, CellState.Dead), new Cell(7, CellState.Dead)}
                }
            };
        }

        public static Cell[,] LoadDefault2dBoard()
        {
            return new[,]
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
                {
                    new Cell(20, CellState.Dead), new Cell(21, CellState.Dead), new Cell(22, CellState.Dead),
                    new Cell(23, CellState.Dead), new Cell(24, CellState.Dead)
                },
            };
        }
    }
}