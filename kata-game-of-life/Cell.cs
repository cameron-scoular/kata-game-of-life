namespace kata_game_of_life
{
    public class Cell
    {
        public CellState CellState { get; private set; }

        public Cell(CellState cellState)
        {
            CellState = cellState;
        }

        public char GetRenderSymbol()
        {
            return CellState == CellState.Alive ? Constants.CellAliveRenderSymbol : Constants.CellDeadRenderSymbol;
        }

    }
}