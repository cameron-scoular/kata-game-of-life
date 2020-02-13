using System.Collections.Generic;

namespace kata_game_of_life
{
    public interface IBoard
    {
        Cell GetCell(int cellId);

        void SetCellState(int cellId, CellState cellState);

        Cell IterateNextCell();

        void ResetCellIterator();
        
        int GetNumberOfCells();

        List<int> GetDimensions();

        int GetAdjacentCellCount(CellState adjacentCellState, int cellId);
        
        
    }
}