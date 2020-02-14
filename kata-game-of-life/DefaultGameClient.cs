using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;

namespace kata_game_of_life
{
    public class DefaultGameClient : IGameClient
    {
        private readonly GameProcessor _gameProcessor;
        private readonly IBoardPersistence _boardPersistence;
        private readonly IGameRenderer _renderer;
        private readonly string _savePath;

        public DefaultGameClient(GameProcessor gameProcessor, IBoardPersistence boardPersistence, IGameRenderer renderer, string savePath)
        {
            _gameProcessor = gameProcessor;
            _boardPersistence = boardPersistence;
            _renderer = renderer;
            _savePath = savePath;
        
        }

        public void PlayGame(IBoard initialBoard)
        {
            var initialGameState = _gameProcessor.StartNewGame(initialBoard, new BoardProcessor());
            
            _renderer.Render(initialGameState);
            
            while (true)
            {
                var nextGameState = _gameProcessor.Tick();
                _renderer.Render(initialGameState);
                
                if (_savePath != null && nextGameState.TickNumber % Configuration.TicksUntilSave == 0)
                {
                    _boardPersistence.SaveBoardState(nextGameState.Board.GetCellArray(), _savePath);
                }
            }
        }
        
    }
}