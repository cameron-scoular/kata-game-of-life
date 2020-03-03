using System;
using System.Collections.Generic;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Board
{
    public class TwoDimensionalBoard : IBoard
    {

        private Cell[,] _cellArray;
        private int _maxX;
        private int _maxY;
        private int _iteratorId;

        public TwoDimensionalBoard(Cell[,] cellArray)
        {
            SetupFields(cellArray);
        }

        public TwoDimensionalBoard(List<int> dimensions)
        {
            var cells = CreateRandomCells(dimensions[0], dimensions[1]);
            SetupFields(cells);
        }

        private void SetupFields(Cell[,] cellArray)
        {
            _cellArray = AssignCellIds(cellArray);
            _maxX = _cellArray.GetLength(0);
            _maxY = _cellArray.GetLength(1);
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
        
        private Cell[,] CreateRandomCells(int xMax, int yMax)
        {
            var cells = new Cell[xMax, yMax];
            var random = new Random();

            for (var x = 0; x < xMax; x++)
            {
                for (var y = 0; y < yMax; y++)
                {
                    cells[x, y] = random.Next(0, 100) > Configuration.DefaultAlivePercent ? new Cell(CellState.Alive) : new Cell(CellState.Dead);
                }
            }

            return cells;
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

        public Cell EnumerateNextCell()
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

        public void ResetCellEnumerator()
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