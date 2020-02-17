using kata_game_of_life.Interfaces;

namespace kata_game_of_life.State
{
    public class GameState
    {

        public IBoardProcessor BoardProcessor { get; private set; }
        public IBoard Board { get; private set; }
        public int TickNumber { get; set; }
        
        
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