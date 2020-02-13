using System;
using System.Collections.Generic;

namespace kata_game_of_life
{
    public class DefaultBoard : IBoard
    {

        private readonly Cell[,] _cellArray;
        private readonly int _maxX;
        private readonly int _maxY;
        private int _iteratorId;

        public DefaultBoard(Cell[,] cellArray)
        {
            _cellArray = cellArray;
            _maxX = cellArray.GetLength(0);
            _maxY = cellArray.GetLength(1);
            _iteratorId = 0;
        }
        
        public Cell GetCell(int cellId)
        {
            var coords = GetCoordinates(cellId);
            return _cellArray[coords.Item1, coords.Item2];
        }

        public void SetCellState(int cellId, CellState cellState)
        {
            GetCell(cellId).CellState = cellState;
        }

        public Cell IterateNextCell()
        {
            Cell cell;
            try
            {
                cell = GetCell(_iteratorId);
                _iteratorId++;
            }
            catch (IndexOutOfRangeException e)
            {
                return null;
            }
            
            return cell;
        }

        public void ResetCellIterator()
        {
            _iteratorId = 0;
        }

        public List<int> GetDimensions()
        {
            return new List<int>()
            {
                _maxX, _maxY
            };
        }

        public int GetAdjacentCellCount(CellState adjacentCellState, int cellId)
        {
            var adjacencyCount = 0;
            var maxX = GetDimensions()[0];
            var maxY = GetDimensions()[1];

            for (var xDelta = -1; xDelta <= 1; xDelta++)
            {
                for (var yDelta = -1; yDelta <= 1; yDelta++)
                {
                    if (xDelta != 0 || yDelta != 0)
                    {
                        var x = GetCoordinates(cellId).Item1;
                        var y = GetCoordinates(cellId).Item2;
  
                        var adjacentX = Modulus((x + xDelta), maxX);
                        var adjacentY = Modulus((y + yDelta), maxY);
                        var adjacentCell = _cellArray[adjacentX, adjacentY];

                        if (adjacentCell.CellState == adjacentCellState)
                        {
                            adjacencyCount++;
                        }
                    }
                }
            }

            return adjacencyCount;
        }

        public object GetCellArray()
        {
            return _cellArray;
        }

        private Tuple<int, int> GetCoordinates(int cellId)
        {
            var x = cellId % _maxX;
            var y = (cellId - x) / _maxX;
            return new Tuple<int, int>(x, y);
        }

        int Modulus(int x, int divisor) {
            // Special modulus method to avoid negatives
            return (x % divisor + divisor) % divisor;
        }

    }
}