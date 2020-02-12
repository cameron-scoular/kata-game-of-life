using System;
using System.Text;

namespace kata_game_of_life
{
    public class GameConsoleRenderer : IGameRenderer
    {

        public void Render(GameState gameState)
        {
            var boardString = new StringBuilder();

            for(var y = gameState.Board.GetLength(1) - 1; y >= 0; y--)
            {
                var boardRowString = "";
                
                for(var x = gameState.Board.GetLength(0) - 1; x >= 0; x--)
                {
                    boardRowString += gameState.Board[x, y].GetRenderSymbol();
                }

                boardString.AppendLine(boardRowString);
            }
            
            Console.WriteLine(boardString);
            Console.WriteLine("Tick " + gameState.TickNumber);
            Console.WriteLine("-------------------------------------");
        }

    }
}