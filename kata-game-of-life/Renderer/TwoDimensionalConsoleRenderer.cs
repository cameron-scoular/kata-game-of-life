using System;
using System.Text;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Renderer
{
    public class TwoDimensionalConsoleRenderer : IGameRenderer
    {

        public void Render(GameState gameState)
        {
            var boardString = GenerateBoardString(gameState);
            var lineBreakerLength = gameState.Board.GetDimensions()[0];
            var lineBreaker = GetLineBreaker(lineBreakerLength);
            
            Console.WriteLine(boardString);
            Console.WriteLine("Tick " + gameState.TickNumber);
            Console.WriteLine(lineBreaker);
        }

        public string GenerateBoardString(GameState gameState)
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

            return boardString.ToString();
        }

        private string GetLineBreaker(int breakerLength)
        {
            var line = string.Empty;

            for (var i = 0; i < breakerLength; i++)
            {
                line += "-";
            }

            return line;
        }

    }
}
