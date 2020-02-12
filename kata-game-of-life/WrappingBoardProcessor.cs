using System;

namespace kata_game_of_life
{
    public class WrappingBoardProcessor : IBoardProcessor
    {
        public Cell[,] GetNextBoard(Cell[,] board)
        {
            var adjacencyCountArray = ConstructAdjacencyCountArray(board);

            return ConstructNextCellBoard(adjacencyCountArray, board);
        }

        private Cell[,] ConstructNextCellBoard(int[,] adjacencyCountArray, Cell[,] oldBoard)
        {
            var maxX = adjacencyCountArray.GetLength(0);
            var maxY = adjacencyCountArray.GetLength(1);
            var newBoard = new Cell[maxX, maxY];

            for(var x = 0; x < maxX; x++)
            {
                for (var y = 0; y < maxY; y++)
                {
                    var newCellState = GetNewCellState(oldBoard[x,y].CellState, adjacencyCountArray[x, y]);
                    newBoard[x, y] = new Cell(newCellState);
                }
            }

            return newBoard;
        }

        private CellState GetNewCellState(CellState initialCellState, int adjacentCellCount)
        {
            switch (initialCellState)
            {
                case CellState.Alive:
                    return adjacentCellCount >= 2 && adjacentCellCount <= 3 ? CellState.Alive : CellState.Dead;
                case CellState.Dead:
                    return adjacentCellCount == 3 ? CellState.Alive : CellState.Dead;
                default:
                    throw new Exception();
            }
        }
        
        private int[,] ConstructAdjacencyCountArray(Cell[,] board)
        {
            var maxX = board.GetLength(0);
            var maxY = board.GetLength(1);
            
            var adjacencyCountArray = new int[maxX, maxY];

            for (var x = 0; x < maxX; x++)
            {
                for (var y = 0; y < maxY; y++)
                {
                    if (board[x, y].CellState == CellState.Alive)
                    {
                        IncrementAllAdjacentCoordinates(adjacencyCountArray, new Coordinate(x, y));
                    }
                }
            }

            return adjacencyCountArray;
        }

        private void IncrementAllAdjacentCoordinates(int[,] adjacencyCountArray, Coordinate coordinate)
        {
            for (var xDelta = -1; xDelta <= 1; xDelta++)
            {
                for (var yDelta = -1; yDelta <= 1; yDelta++)
                {
                    if (xDelta != 0 || yDelta != 0)
                    {
                        IncrementAdjacentCoordinate(adjacencyCountArray, coordinate, xDelta, yDelta);
                    }
                }
            }
        }

        private void IncrementAdjacentCoordinate(int[,] adjacencyCountArray, Coordinate coordinate, int xDelta, int yDelta)
        {
            var maxX = adjacencyCountArray.GetLength(0);
            var maxY = adjacencyCountArray.GetLength(1);
            var adjacentX = Modulus((coordinate.X + xDelta), maxX);
            var adjacentY = Modulus((coordinate.Y + yDelta), maxY);

            adjacencyCountArray[adjacentX, adjacentY]++;
        }

        int Modulus(int x, int divisor) {
            // Special modulus method to avoid negatives
            return (x % divisor + divisor) % divisor;
        }
    }
}