using System;
using System.Collections.Generic;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Boards
{
    public class TwoDimensionalBoard : IBoard
    {

        private readonly Cell[,] _cellArray;
        private readonly int _maxX;
        private readonly int _maxY;
        private int _iteratorId;

        public TwoDimensionalBoard(Cell[,] cellArray)
        {
            _cellArray = AssignCellIds(cellArray);
            _maxX = cellArray.GetLength(0);
            _maxY = cellArray.GetLength(1);
            _iteratorId = 0;
        }

        private Cell[,] AssignCellIds(Cell[,] cellArray)
        {
            var id = 0;
            foreach(var cell in cellArray)
            {
                cell.CellId = id;
                id++;
            }

            return cellArray;
        }
        
        public Cell GetCell(int cellId)
        {
            var (x, y) = GetCoordinates(cellId);
            return _cellArray[x, y];
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

        public int GetAdjacentCellCount(CellState cellStateToCount, int cellId)
        {
            var adjacencyCount = 0;

            for (var xDelta = -1; xDelta <= 1; xDelta++)
            {
                for (var yDelta = -1; yDelta <= 1; yDelta++)
                {
                    if (xDelta != 0 || yDelta != 0)
                    {
                        var (x, y) = GetCoordinates(cellId);
                        
                        var adjacentX = Modulus((x + xDelta), _maxX);
                        var adjacentY = Modulus((y + yDelta), _maxY);
                        var adjacentCell = _cellArray[adjacentX, adjacentY];

                        if (adjacentCell.CellState == cellStateToCount)
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