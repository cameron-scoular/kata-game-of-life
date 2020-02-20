using System.Runtime.CompilerServices;
using kata_game_of_life.Board;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life.Persistence
{
    public static class TypeLoader
    {

        public static IBoard LoadTwoDimensionalBoard(dynamic cellArrayState)
        {
            return new TwoDimensionalBoard((Cell[,])cellArrayState.ToObject<Cell[,]>());
        }
        
        public static IBoard LoadThreeDimensionalBoard(dynamic cellArrayState)
        {
            return new ThreeDimensionalBoard((Cell[,,])cellArrayState.ToObject<Cell[,,]>());
        }
        
        public static IBoardProcessor LoadDefaultBoardProcessor(RuleSet ruleSet)
        {
            return new DefaultBoardProcessor(ruleSet);
        }
    }
}