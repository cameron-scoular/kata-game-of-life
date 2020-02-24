using System;
using System.Collections.Generic;
using System.Text;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Renderer
{
    public class ThreeDimensionalConsoleRenderer : IGameRenderer
    {

        public void Render(GameState gameState)
        {
            var boardString = GenerateBoardString(gameState);
            var lineBreaker = GetLineBreaker(gameState.Board.GetDimensions());
            
            Console.WriteLine(lineBreaker);
            Console.WriteLine(boardString);
            Console.WriteLine("Tick " + gameState.TickNumber);
            Console.WriteLine(lineBreaker);
        }

        public string GenerateBoardString(GameState gameState)
        {
            var lineBreaker = GetLineBreaker(gameState.Board.GetDimensions());

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

        private string GetLineBreaker(List<int> dimensions)
        {
            var lineBreakerLength = (dimensions[0] + 3) * dimensions[2];

            var line = string.Empty;

            for (var i = 0; i < lineBreakerLength; i++)
            {
                line += "-";
            }

            return line;
        }

    }
}