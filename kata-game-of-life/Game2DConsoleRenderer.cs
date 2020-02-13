using System;
using System.Text;
using System.Xml.Schema;

namespace kata_game_of_life
{
    public class Game2DConsoleRenderer : IGameRenderer
    {

        public void Render(GameState gameState)
        {
            var boardString = new StringBuilder();

            var maxX = gameState.Board.GetDimensions()[0];
            var maxY = gameState.Board.GetDimensions()[1];

            for(var y = maxY - 1; y >= 0; y--)
            {
                var boardRowString = "";
                
                for(var x = maxX - 1; x >= 0; x--)
                {
                    boardRowString += gameState.Board.GetCell(y * maxX + x).GetRenderSymbol();
                }

                boardString.AppendLine(boardRowString);
            }
            
            Console.WriteLine(boardString);
            Console.WriteLine("Tick " + gameState.TickNumber);
            Console.WriteLine("-------------------------------------");
        }

    }
}