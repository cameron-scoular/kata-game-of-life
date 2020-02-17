using kata_game_of_life.Boards;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;
using kata_game_of_life.State;
using Newtonsoft.Json;

namespace kata_game_of_life
{
    public class LoopingGameClient : IGameClient
    {
        private readonly GameProcessor _gameProcessor;
        private readonly IGamePersistence _gamePersistence;
        private readonly INewGameLoader _newGameLoader;
        private readonly IGameRenderer _renderer;
        private readonly string _savePath;

        public LoopingGameClient(GameProcessor gameProcessor, IGamePersistence gamePersistence, INewGameLoader newGameLoader, IGameRenderer renderer, string savePath)
        {
            _gameProcessor = gameProcessor;
            _gamePersistence = gamePersistence;
            _newGameLoader = newGameLoader;
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
                initialGameState = _newGameLoader.LoadNewGame(arguments);
            }

            return initialGameState;
        }
    }
}