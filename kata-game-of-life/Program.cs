using System;

namespace kata_game_of_life
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var gameProcessor = new GameProcessor(1000);
            var renderer = new Game2DConsoleRenderer();

            var savedBoardPath =
                "/Users/cameron.scoular/Desktop/Code/kata-game-of-life/kata-game-of-life/Boards/board_1.txt";
            
            var boardPersistence = new Local2DBoardPersistence();
            
            var cellArray = boardPersistence.LoadBoardState(savedBoardPath);
            
            var board = new DefaultBoard(cellArray);
            
            //var initialGameState = gameProcessor.StartNewGame(defaultBoard);
            var initialGameState = gameProcessor.StartNewGame(board, new BoardProcessor());
            
            renderer.Render(initialGameState);

            while (true)
            {
              var nextGameState = gameProcessor.Tick();
              renderer.Render(nextGameState);

              /*
              if (nextGameState.TickNumber % 5 == 0)
              {
                  boardPersistence.SaveBoardState(nextGameState.Board, savedBoardPath);
              }*/
            }
            
        }
        
        
    }
}