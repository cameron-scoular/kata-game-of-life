using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    public class LoopingGameClient : IGameClient
    {
        private readonly GameProcessor _gameProcessor;
        private readonly INewGameProvider _localNewGameProvider;
        private readonly IGamePersistence _gamePersistence;
        private readonly IGameRendererFactory _gameRendererFactory;
        private IGameRenderer _renderer;
        private readonly string _savePath;

        public LoopingGameClient(GameProcessor gameProcessor, INewGameProvider localNewGameProvider, IGamePersistence gamePersistence, IGameRendererFactory gameRendererFactory, string savePath)
        {
            _gameProcessor = gameProcessor;
            _localNewGameProvider = localNewGameProvider;
            _gamePersistence = gamePersistence;
            _gameRendererFactory = gameRendererFactory;
            _savePath = savePath;
        
        }

        public void PlayGame(Arguments arguments)
        {
            var initialGameState = LoadInitialGameState(arguments);
            _renderer = _gameRendererFactory.CreateGameRenderer(initialGameState.Board.GetType());

            initialGameState = _gameProcessor.StartNewGame(initialGameState);
            _renderer.Render(initialGameState);
            
            while (true)
            {
                var nextGameState = _gameProcessor.Tick();
                _renderer.Render(initialGameState);
                
                if (ShouldSaveGame(nextGameState))
                {
                    _gamePersistence.SaveGame(nextGameState, _savePath);
                }
            }
        }

        private bool ShouldSaveGame(GameState nextGameState)
        {
            return _savePath != null && nextGameState.TickNumber % Configuration.TicksUntilSave == 0;
        }

        private GameState LoadInitialGameState(Arguments arguments)
        {
            GameState initialGameState;

            if (arguments.LoadFileName != null && _gamePersistence.FileIsSaveFile(arguments.LoadFileName))
            {
                initialGameState = _gamePersistence.LoadGame(arguments.LoadFileName);
            }
            else
            {
                
                initialGameState = _localNewGameProvider.LoadNewGame(arguments);

            }
            
            return initialGameState;
        }
    }
}