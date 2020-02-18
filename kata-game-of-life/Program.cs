using kata_game_of_life.GameRenderers;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;

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
            
            var client = new LoopingGameClient(gameProcessor, gamePersistence, new LocalNewGameProvider(),renderer, arguments.SaveFileName);
            
            client.PlayGame(arguments);
        }

    }
}