namespace kata_game_of_life.State
{
    public class Cell
    {
        public int CellId { get; set; }
        public CellState CellState { get; set; }

        public Cell()
        {
        }

        public Cell(int cellId, CellState cellState)
        {
            CellId = cellId;
            CellState = cellState;
        }
        
        public Cell(CellState cellState)
        {
            CellState = cellState;
        }

        public char GetRenderSymbol()
        {
            return CellState == CellState.Alive ? Configuration.CellAliveRenderSymbol : Configuration.CellDeadRenderSymbol;
        }

    }
}