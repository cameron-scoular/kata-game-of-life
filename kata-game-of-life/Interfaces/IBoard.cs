using System.Collections.Generic;
using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface IBoard
    {
        Cell GetCell(int cellId);
        
        object GetCellArray();
        
        List<int> GetDimensions();

        int GetAdjacentCellCount(CellState cellStateToCount, int cellId);
        
        void SetCellState(int cellId, CellState cellState);
        
        Cell EnumerateNextCell();
        
        void ResetCellEnumerator();

    }
}