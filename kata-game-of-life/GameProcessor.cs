using System.Diagnostics;
using System.Threading;

namespace kata_game_of_life
{
    public class GameProcessor
    {
        public int TickPeriod { get; private set; }
        public GameState GameState { get; private set; }
        public GameProcessor(int tickPeriod)
        {
            TickPeriod = tickPeriod;
        }

        public GameState Tick()
        {
            GameState.Tick();
            Thread.Sleep(TickPeriod);
            return GameState;
        }
        
        

        public GameState StartNewGame(Cell[,] startingBoard, IBoardProcessor boardProcessor)
        {
            GameState = new GameState(startingBoard, boardProcessor);
            return GameState;
        }
        
    }
}