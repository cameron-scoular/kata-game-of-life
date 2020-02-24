using kata_game_of_life.Board;
using kata_game_of_life.BoardLoaders;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;
using kata_game_of_life.Renderer;

namespace kata_game_of_life
{
    class Program
    {

        static void Main(string[] args)
        {
            var arguments = ArgumentParser.ParseArguments(args);
            
            RegisterComponents();
            var loaderFactory = new LoaderFactory();
            var newGameProvider = new LocalNewGameProvider(loaderFactory);
            var gameProcessor = new GameProcessor(Configuration.TickPeriod);
            var gamePersistence = new LocalGamePersistence(loaderFactory, Configuration.DefaultSaveDirectory);
            var gameRendererFactory = new GameRendererFactory();
            
            var client = new LoopingGameClient(gameProcessor, newGameProvider, gamePersistence, gameRendererFactory, arguments.SaveFileName);
            
            client.PlayGame(arguments);
        }

        static void RegisterComponents()
        {
            var componentRegister = ComponentRegister.GetComponentRegisterInstance();
            
            componentRegister.RegisterComponent<IBoardLoader>(typeof(TwoDimensionalBoard), new TwoDimensionalBoardLoader());
            
            componentRegister.RegisterComponent<IBoardLoader>(typeof(ThreeDimensionalBoard), new ThreeDimensionalBoardLoader());
            
            componentRegister.RegisterComponent<IBoardProcessorLoader>(new BoardProcessorLoader());
            
            componentRegister.RegisterComponent<IGameRenderer>(typeof(TwoDimensionalBoard), new TwoDimensionalConsoleRenderer());
            
            componentRegister.RegisterComponent<IGameRenderer>(typeof(ThreeDimensionalBoard), new ThreeDimensionalConsoleRenderer());
            
            componentRegister.RegisterComponent<INewGameLoader>(typeof(TwoDimensionalBoard), new TwoDimensionalNewGameLoader());
            
            componentRegister.RegisterComponent<INewGameLoader>(typeof(ThreeDimensionalBoard), new ThreeDimensionalNewGameLoader());

        }

    }
}