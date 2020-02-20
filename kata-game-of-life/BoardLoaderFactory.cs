using System;
using kata_game_of_life.Interfaces;

namespace kata_game_of_life
{
    public class BoardLoaderFactory : IBoardLoaderFactory
    {
        
        private readonly ComponentRegister _componentRegister = ComponentRegister.GetComponentRegisterInstance();
        
        public Func<object, IBoard> CreateBoardLoader(Type boardType)
        {
            return _componentRegister.ResolveComponent<Func<object, IBoard>>(boardType);
        }

        public Func<RuleSet, IBoardProcessor> CreateBoardProcessorLoader(Type boardProcessorType)
        {
            return _componentRegister.ResolveComponent<Func<RuleSet, IBoardProcessor>>(boardProcessorType);
        }
    }
}