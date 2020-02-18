using System;
using System.Collections.Generic;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Processors
{
    public class DefaultBoardProcessor : IBoardProcessor
    {


        public int AliveToAliveLowerBound { get; }
        public int DeadToAliveUpperBound { get; }
        public int DeadToAliveLowerBound { get; }
        public int AliveToAliveUpperBound { get; }
        

        public DefaultBoardProcessor(string ruleSet)
        {
            AliveToAliveLowerBound = int.Parse(ruleSet[0].ToString());
            AliveToAliveUpperBound = int.Parse(ruleSet[1].ToString());
            DeadToAliveLowerBound = int.Parse(ruleSet[2].ToString());
            DeadToAliveUpperBound = int.Parse(ruleSet[3].ToString());
        }

        

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
                    return adjacentCellCount >= AliveToAliveLowerBound && adjacentCellCount <= AliveToAliveUpperBound
                        ? CellState.Alive
                        : CellState.Dead;
                case CellState.Dead:
                    return adjacentCellCount >= DeadToAliveLowerBound && adjacentCellCount <= DeadToAliveUpperBound 
                        ? CellState.Alive 
                        : CellState.Dead;
                default:
                    throw new Exception();
            }
        }

        private Dictionary<int, int> ConstructAdjacencyCountDictionary(IBoard board)
        {
            
            var adjacencyCountDictionary = new Dictionary<int, int>();

            board.ResetCellEnumerator();
            var nextCell = board.EnumerateNextCell();

            while (nextCell != null)
            {
                var adjacentCellCount = board.GetAdjacentCellCount(CellState.Alive, nextCell.CellId);
                adjacencyCountDictionary.Add(nextCell.CellId, adjacentCellCount);
                nextCell = board.EnumerateNextCell();
            }
            
            return adjacencyCountDictionary;
        }

        
    }
}