using System;
using System.Collections.Generic;
using kata_game_of_life.Boards;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life.Persistence
{
    public static class TypeLoader
    {
        
        public static Dictionary<Type, Func<object, IBoard>> BoardLoaderMappings = new Dictionary<Type, Func<object, IBoard>>()
        {
            {typeof(TwoDimensionalBoard), LoadTwoDimensionalBoard},
            {typeof(ThreeDimensionalBoard), LoadThreeDimensionalBoard},
        };
        
        public static Dictionary<Type, Func<IBoardProcessor>> BoardProcessorMappings = new Dictionary<Type, Func<IBoardProcessor>>()
        {
            {typeof(DefaultBoardProcessor), LoadDefaultBoardProcessor}
        };
        
        public static IBoard LoadTwoDimensionalBoard(dynamic cellArrayState)
        {
            return new TwoDimensionalBoard((Cell[,])cellArrayState.ToObject<Cell[,]>());
            
        }
        
        public static IBoard LoadThreeDimensionalBoard(dynamic cellArrayState)
        {
            return new ThreeDimensionalBoard((Cell[,,])cellArrayState.ToObject<Cell[,,]>());
        }
        
        public static IBoardProcessor LoadDefaultBoardProcessor()
        {
            return new DefaultBoardProcessor();
        }
    }
}