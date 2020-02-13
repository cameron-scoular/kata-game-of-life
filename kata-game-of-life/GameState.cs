namespace kata_game_of_life
{
    public class GameState
    {

        private IBoardProcessor BoardProcessor;
        public IBoard Board { get; private set; }
        public int TickNumber { get; private set; }
        
        
        public GameState(IBoard board, IBoardProcessor boardProcessor)
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