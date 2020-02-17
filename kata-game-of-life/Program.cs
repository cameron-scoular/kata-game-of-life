using System;
using kata_game_of_life.Boards;
using kata_game_of_life.GameRenderers;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    class Program
    {

        static void Main(string[] args)
        {
            var arguments = ArgumentParser.ParseArguments(args);

            var gameProcessor = new GameProcessor(Configuration.TickPeriod);
            var renderer = new ConsoleRenderer();;
            var gamePersistence = new LocalGamePersistence();
            
            var client = new LoopingGameClient(gameProcessor, gamePersistence, new LocalNewGameLoader(),renderer, arguments.SaveFileName);
            
            client.PlayGame(arguments);
        }

    }
}