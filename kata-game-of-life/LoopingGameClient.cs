using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    public class LoopingGameClient : IGameClient
    {
        private readonly GameProcessor _gameProcessor;
        private readonly IGamePersistence _gamePersistence;
        private readonly INewGameProvider _newGameProvider;
        private readonly IGameRenderer _renderer;
        private readonly string _savePath;

        public LoopingGameClient(GameProcessor gameProcessor, IGamePersistence gamePersistence, INewGameProvider newGameProvider, IGameRenderer renderer, string savePath)
        {
            _gameProcessor = gameProcessor;
            _gamePersistence = gamePersistence;
            _newGameProvider = newGameProvider;
            _renderer = renderer;
            _savePath = savePath;
        
        }

        public void PlayGame(Arguments arguments)
        {
            var initialGameState = LoadInitialGameState(arguments);

            initialGameState = _gameProcessor.StartNewGame(initialGameState);
            _renderer.Render(initialGameState);
            
            while (true)
            {
                var nextGameState = _gameProcessor.Tick();
                _renderer.Render(initialGameState);
                
                if (_savePath != null && nextGameState.TickNumber % Configuration.TicksUntilSave == 0)
                {
                    _gamePersistence.SaveGame(nextGameState, _savePath);
                }
            }
        }

        private GameState LoadInitialGameState(Arguments arguments)
        {
            GameState initialGameState;

            if (arguments.LoadFileName != null && _gamePersistence.FileIsPersistent(arguments.LoadFileName))
            {
                initialGameState = _gamePersistence.LoadGame(arguments.LoadFileName);
            }
            else
            {
                initialGameState = _newGameProvider.LoadNewGame(arguments);
            }

            return initialGameState;
        }
    }
}