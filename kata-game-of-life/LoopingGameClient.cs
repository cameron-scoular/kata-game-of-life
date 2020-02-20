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
        private readonly IGameRendererFactory _gameRendererFactory;
        private IGameRenderer _renderer;
        private readonly string _savePath;

        public LoopingGameClient(GameProcessor gameProcessor, IGamePersistence gamePersistence, INewGameProvider newGameProvider, IGameRendererFactory gameRendererFactory, string savePath)
        {
            _gameProcessor = gameProcessor;
            _gamePersistence = gamePersistence;
            _newGameProvider = newGameProvider;
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

            if (arguments.LoadFileName != null && _gamePersistence.FileHasBeenSaved(arguments.LoadFileName))
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