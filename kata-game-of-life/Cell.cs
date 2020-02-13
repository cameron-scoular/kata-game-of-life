using System.Net.NetworkInformation;

namespace kata_game_of_life
{
    public class Cell
    {
        public int CellId { get; private set; }
        public CellState CellState { get; set; }

        public Cell(int cellId, CellState cellState)
        {
            CellId = cellId;
            CellState = cellState;
        }

        public char GetRenderSymbol()
        {
            return CellState == CellState.Alive ? Constants.CellAliveRenderSymbol : Constants.CellDeadRenderSymbol;
        }

    }
}