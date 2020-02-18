using System.Threading;
using kata_game_of_life.State;

namespace kata_game_of_life.Processors
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
        
        public GameState StartNewGame(GameState initialGameState)
        {
            GameState = initialGameState;
            return GameState;
        }
        
    }
}