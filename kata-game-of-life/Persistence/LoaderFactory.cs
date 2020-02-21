using System;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;

namespace kata_game_of_life.Board
{
    public class LoaderFactory : ILoaderFactory
    {
        
        private readonly ComponentRegister _componentRegister = ComponentRegister.GetComponentRegisterInstance();
        
        public IBoardLoader CreateBoardLoader(Type boardType)
        {
            return _componentRegister.ResolveComponent<IBoardLoader>(boardType);
        }

        public IBoardProcessorLoader CreateBoardProcessorLoader()
        {
            return _componentRegister.ResolveComponent<IBoardProcessorLoader>();
        }
    }
}