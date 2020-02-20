using System;
using System.Collections.Generic;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Board
{
    public class ThreeDimensionalBoard : IBoard
    {

        private Cell[,,] _cellArray;
        private int _maxX;
        private int _maxY;
        private int _maxZ;
        private int _iteratorId;
        
        public ThreeDimensionalBoard(Cell[,,] cellArray)
        {
            SetupFields(cellArray);
        }

        public ThreeDimensionalBoard(List<int> dimensions)
        {
            var cells = CreateRandomCells(dimensions[0], dimensions[1], dimensions[2]);
            SetupFields(cells);
        }

        private void SetupFields(Cell[,,] cellArray)
        {
            _cellArray = AssignCellIds(cellArray);
            _maxX = _cellArray.GetLength(0);
            _maxY = _cellArray.GetLength(1);
            _maxZ = _cellArray.GetLength(2);
            _iteratorId = 0;
        }
        
        private Cell[,,] CreateRandomCells(int xMax, int yMax, int zMax)
        {
            var cells = new Cell[10, 10, 10];
            var random = new Random();

            for (var x = 0; x < xMax; x++)
            {
                for (var y = 0; y < yMax; y++)
                {
                    for (var z = 0; z < zMax; z++)
                    {
                        cells[x, y, z] = random.Next(0, 100) > Configuration.DefaultAlivePercent ? new Cell(CellState.Alive) : new Cell(CellState.Dead);
                    }
                }
            }

            return cells;
        }

        private Cell[,,] AssignCellIds(Cell[,,] cellArray)
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
            var (x, y, z) = GetCoordinates(cellId);
            return _cellArray[x, y, z];
        }

        public void SetCellState(int cellId, CellState cellState)
        {
            var cell = GetCell(cellId);
            cell.CellState = cellState;
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
                _maxX, _maxY, _maxZ
            };
        }

        public int GetAdjacentCellCount(CellState cellStateToCount, int cellId)
        {
            var adjacencyCount = 0;
            
            for (var xDelta = -1; xDelta <= 1; xDelta++)
            {
                for (var yDelta = -1; yDelta <= 1; yDelta++)
                {
                    for (var zDelta = -1; zDelta <= 1; zDelta++)
                    {
                        if (xDelta == 0 && yDelta == 0 && zDelta == 0) continue;
                        
                        var adjacentCell = GetAdjacentCell(cellId, xDelta, yDelta, zDelta);
                        
                        if (adjacentCell.CellState == cellStateToCount)
                        {
                            adjacencyCount++;
                        }
                    }
                }
            }

            return adjacencyCount;
            
        }

        private Cell GetAdjacentCell(int cellId, int xDelta, int yDelta, int zDelta)
        {
            var (x, y, z) = GetCoordinates(cellId);

            var adjacentX = Modulus((x + xDelta), _maxX);
            var adjacentY = Modulus((y + yDelta), _maxY);
            var adjacentZ = Modulus((z + zDelta), _maxZ);

            var adjacentCell = _cellArray[adjacentX, adjacentY, adjacentZ];
            return adjacentCell;
        }

        public object GetCellArray()
        {
            return _cellArray;
        }
        
        private Tuple<int, int, int> GetCoordinates(int cellId)
        {
            var x = cellId % _maxX;
            var y = (cellId / _maxX) % _maxY;
            var z = cellId / (_maxX * _maxY);

            return new Tuple<int, int, int>(x, y, z);
        }
        
        int Modulus(int x, int divisor) {
            // Special modulus method to avoid negatives
            return (x % divisor + divisor) % divisor;
        }
    }
}