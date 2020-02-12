namespace kata_game_of_life
{
    public class GameState
    {

        private IBoardProcessor BoardProcessor;
        public Cell[,] Board { get; private set; }
        public int TickNumber { get; private set; }
        
        
        public GameState(Cell[,] board, IBoardProcessor boardProcessor)
        {
            BoardProcessor = boardProcessor;
            Board = board;
            TickNumber = 0;
        }

        public void Tick()
        {
            Board = BoardProcessor.GetNextBoard(Board);
            TickNumber++;
        }
        
    }
}