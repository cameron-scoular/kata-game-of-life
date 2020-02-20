﻿using System;
using kata_game_of_life.Boards;
using kata_game_of_life.GameRenderers;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;

namespace kata_game_of_life
{
    class Program
    {

        static void Main(string[] args)
        {
            var arguments = ArgumentParser.ParseArguments(args);
            
            RegisterComponents();

            var gameProcessor = new GameProcessor(Configuration.TickPeriod);
            var gamePersistence = new LocalGamePersistence(new BoardLoaderFactory());
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

            var defaultBoardProcessorLoadFunction = new Func<int, IBoardProcessor>(TypeLoader.LoadDefaultBoardProcessor); 
            componentRegister.RegisterComponent<Func<object, IBoardProcessor>>(typeof(TwoDimensionalBoard), defaultBoardProcessorLoadFunction);
            
            var twoDimensionalConsoleRenderer = new TwoDimensionalConsoleRenderer();
            componentRegister.RegisterComponent<IGameRenderer>(typeof(TwoDimensionalBoard), twoDimensionalConsoleRenderer);
            
            var threeDimensionalConsoleRenderer = new ThreeDimensionalConsoleRenderer();
            componentRegister.RegisterComponent<IGameRenderer>(typeof(ThreeDimensionalBoard), threeDimensionalConsoleRenderer);
            
        }

    }
}