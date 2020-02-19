using System;
using System.Text;
using kata_game_of_life.Boards;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.GameRenderers
{
    public class ConsoleRenderer : IGameRenderer
    {
        public void Render(GameState gameState)
        {
            dynamic board = gameState.Board;
            var boardString = GenerateBoardString(board);
            
            Console.WriteLine(boardString);
            Console.WriteLine("Tick " + gameState.TickNumber);
        }
        
        public string GenerateBoardString(TwoDimensionalBoard board)
        {
            var lineBreakerLength = board.GetDimensions()[0];
            var lineBreaker = GetLineBreaker(lineBreakerLength);

            var boardString = new StringBuilder();
            boardString.AppendLine(lineBreaker);

            var maxX = board.GetDimensions()[0];
            var maxY = board.GetDimensions()[1];

            for(var y = maxY - 1; y >= 0; y--)
            {
                var boardRowString = "";
                
                for(var x = maxX - 1; x >= 0; x--)
                {
                    boardRowString += board.GetCell(y * maxX + x).GetRenderSymbol();
                }

                boardString.AppendLine(boardRowString);
            }

            boardString.AppendLine(lineBreaker);
            
            return boardString.ToString();
        }

        public string GenerateBoardString(ThreeDimensionalBoard board)
        {
            var lineBreakerLength = board.GetDimensions()[0] * board.GetDimensions()[2];
            var lineBreaker = GetLineBreaker(lineBreakerLength);

            var boardString = new StringBuilder();
            boardString.AppendLine(lineBreaker);

            var maxX = board.GetDimensions()[0];
            var maxY = board.GetDimensions()[1];
            var maxZ = board.GetDimensions()[2];

            for(var y = maxY - 1; y >= 0; y--)
            {
                var boardRowString = "";

                for (var z = 0; z < maxZ; z++)
                {
                    for(var x = maxX - 1; x >= 0; x--)
                    {
                        boardRowString += board.GetCell(z * maxX * maxY + y * maxX + x).GetRenderSymbol();
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