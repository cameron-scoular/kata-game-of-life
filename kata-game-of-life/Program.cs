using System;
using kata_game_of_life.Board;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;
using kata_game_of_life.Renderer;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    class Program
    {

        static void Main(string[] args)
        {
            var arguments = ArgumentParser.ParseArguments(args);
            
            RegisterComponents();

            var gameProcessor = new GameProcessor(Configuration.TickPeriod);
            var gamePersistence = new LocalGamePersistence(new BoardLoaderFactory(), Configuration.DefaultSaveDirectory);
            var newGameProvider = new LocalNewGameProvider();
            var gameRendererFactory = new GameRendererFactory();
            
            var client = new LoopingGameClient(gameProcessor, gamePersistence, newGameProvider, gameRendererFactory, arguments.SaveFileName);
            
            client.PlayGame(arguments);
        }

        static void RegisterComponents()
        {
            var componentRegister = ComponentRegister.GetComponentRegisterInstance();
            
            var twoDimensionalBoardLoadFunction = new Func<object, IBoard>(TypeLoader.LoadTwoDimensionalBoard);
            componentRegister.RegisterComponent<Func<object, IBoard>>(typeof(TwoDimensionalBoard), twoDimensionalBoardLoadFunction);
            
            var threeDimensionalBoardLoadFunction = new Func<object, IBoard>(TypeLoader.LoadThreeDimensionalBoard);
            componentRegister.RegisterComponent<Func<object, IBoard>>(typeof(ThreeDimensionalBoard), threeDimensionalBoardLoadFunction);

            var defaultBoardProcessorLoadFunction = new Func<RuleSet, IBoardProcessor>(TypeLoader.LoadDefaultBoardProcessor); 
            componentRegister.RegisterComponent<Func<object, IBoardProcessor>>(typeof(TwoDimensionalBoard), defaultBoardProcessorLoadFunction);
            
            var twoDimensionalConsoleRenderer = new TwoDimensionalConsoleRenderer();
            componentRegister.RegisterComponent<IGameRenderer>(typeof(TwoDimensionalBoard), twoDimensionalConsoleRenderer);
            
            var threeDimensionalConsoleRenderer = new ThreeDimensionalConsoleRenderer();
            componentRegister.RegisterComponent<IGameRenderer>(typeof(ThreeDimensionalBoard), threeDimensionalConsoleRenderer);
            
            componentRegister.RegisterComponent<Type>(typeof(TwoDimensionalBoard), 2);
        }

    }
}