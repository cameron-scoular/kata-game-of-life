using System;
using System.Collections.Generic;

namespace kata_game_of_life
{
    public class BoardProcessor : IBoardProcessor
    {
        public IBoard GetNextBoard(IBoard board)
        {
            var adjacencyCountDictionary = ConstructAdjacencyCountDictionary(board);

            return ConstructNextBoard(adjacencyCountDictionary, board);
        }

        private IBoard ConstructNextBoard(Dictionary<int, int> adjacencyCountDictionary, IBoard board)
        {
            foreach (var (cellId, adjacencyCount) in adjacencyCountDictionary)
            {
                var oldCellState = board.GetCell(cellId).CellState;
                var newCellState = GetNewCellState(oldCellState, adjacencyCount);
                board.SetCellState(cellId, newCellState);
            }

            return board;
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

        private Dictionary<int, int> ConstructAdjacencyCountDictionary(IBoard board)
        {
            
            var adjacencyCountDictionary = new Dictionary<int, int>();

            board.ResetCellIterator();
            var nextCell = board.IterateNextCell();

            while (nextCell != null)
            {
                var adjacentCellCount = board.GetAdjacentCellCount(CellState.Alive, nextCell.CellId);
                adjacencyCountDictionary.Add(nextCell.CellId, adjacentCellCount);
                nextCell = board.IterateNextCell();
            }
            
            return adjacencyCountDictionary;
        }

        
    }
}