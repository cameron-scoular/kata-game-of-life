using System;
using kata_game_of_life.Boards;
using kata_game_of_life.GameRenderers;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    class Program
    {

        static void Main(string[] args)
        {
            var arguments = ArgumentParser.ParseArguments(args);

            switch (arguments.Dimensions)
            {
                case 2:
                    Play2DConsoleGame(arguments);
                    break;
                case 3:
                    Play3DGame(arguments);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void Play3DGame(Arguments arguments)
        {
            
            var gameProcessor = new GameProcessor(Configuration.TickPeriod);
            var renderer = new ThreeDimensionalConsoleRenderer();
            var boardPersistence = new LocalBoardPersistence();

            var cellArray = Load3DCellArray(arguments, boardPersistence);
            var board = new ThreeDimensionalBoard(cellArray);

            var client = new LoopingGameClient(gameProcessor, boardPersistence, renderer, arguments.SaveFileName);
            
            client.PlayGame(board);
            
        }

        private static void Play2DConsoleGame(Arguments arguments)
        {
            
            var gameProcessor = new GameProcessor(Configuration.TickPeriod);
            var renderer = new TwoDimensionalConsoleRenderer();
            var boardPersistence = new LocalBoardPersistence();

            var cellArray = Load2DCellArray(arguments, boardPersistence);
            var board = new TwoDimensionalBoard(cellArray);
            
            var client = new LoopingGameClient(gameProcessor, boardPersistence, renderer, arguments.SaveFileName);
            
            client.PlayGame(board);
        }

        private static Cell[,,] Load3DCellArray(Arguments arguments, LocalBoardPersistence boardPersistence)
        {
            Cell[,,] cellArray;
            
            if (arguments.LoadResourceName != null)
            {
                throw new NotImplementedException();
            }
            else if (arguments.LoadFileName != null)
            {
                cellArray = boardPersistence.LoadBoardState<Cell[,,]>(arguments.LoadFileName);
            }
            else
            {
                cellArray = NewGameLoader.LoadDefault3dBoard();
            }

            return cellArray;
        }

        private static Cell[,] Load2DCellArray(Arguments arguments, LocalBoardPersistence boardPersistence)
        {
            Cell[,] cellArray;
            
            if (arguments.LoadResourceName != null)
            {
                cellArray = NewGameLoader.LoadNew2dCellArray(arguments.LoadResourceName);
            }
            else if (arguments.LoadFileName != null)
            {
                cellArray = boardPersistence.LoadBoardState<Cell[,]>(arguments.LoadFileName);
            }
            else
            {
                cellArray = NewGameLoader.LoadDefault2dBoard();
            }

            return cellArray;
        }
    }
}