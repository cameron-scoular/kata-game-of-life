using System;

namespace kata_game_of_life
{
    class Program
    {
        
        private static readonly Cell[,] defaultBoard = 
        {
            {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
            {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
            {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
        };
        
        static void Main(string[] args)
        {
            
            var gameProcessor = new GameProcessor(1000);
            var renderer = new GameConsoleRenderer();

            var savedBoardPath =
                "/Users/cameron.scoular/Desktop/Code/kata-game-of-life/kata-game-of-life/Boards/board_1.txt";
            
            var boardPersistence = new LocalBoardPersistence();
            
            var boardState = boardPersistence.LoadBoardState(savedBoardPath);
            
            //var initialGameState = gameProcessor.StartNewGame(defaultBoard);
            var initialGameState = gameProcessor.StartNewGame(boardState, new WrappingBoardProcessor());
            
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