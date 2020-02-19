using System;
using System.Text;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.GameRenderers
{
    public class ThreeDimensionalConsoleRenderer : IGameRenderer
    {

        public void Render(GameState gameState)
        {
            var boardString = GenerateBoardString(gameState);
            var lineBreakerLength = gameState.Board.GetDimensions()[0];
            var lineBreaker = GetLineBreaker(lineBreakerLength);
            
            Console.WriteLine(lineBreaker);
            Console.WriteLine(boardString);
            Console.WriteLine("Tick " + gameState.TickNumber);
            Console.WriteLine(lineBreaker);
        }

        public string GenerateBoardString(GameState gameState)
        {
            var lineBreakerLength = gameState.Board.GetDimensions()[0] * gameState.Board.GetDimensions()[2];
            var lineBreaker = GetLineBreaker(lineBreakerLength);

            var boardString = new StringBuilder();
            boardString.AppendLine(lineBreaker);

            var maxX = gameState.Board.GetDimensions()[0];
            var maxY = gameState.Board.GetDimensions()[1];
            var maxZ = gameState.Board.GetDimensions()[2];

            for(var y = maxY - 1; y >= 0; y--)
            {
                var boardRowString = "";

                for (var z = 0; z < maxZ; z++)
                {
                    for(var x = maxX - 1; x >= 0; x--)
                    {
                        boardRowString += gameState.Board.GetCell(z * maxX * maxY + y * maxX + x).GetRenderSymbol();
                    }

                    boardRowString += " | ";
                }
                boardString.AppendLine(boardRowString);
            }

            boardString.AppendLine(lineBreaker);
            
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