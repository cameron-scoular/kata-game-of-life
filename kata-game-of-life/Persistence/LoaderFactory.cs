using System;
using kata_game_of_life.Interfaces;

namespace kata_game_of_life.Persistence
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

        public INewGameLoader CreateNewGameLoader(Type boardType)
        {
            return _componentRegister.ResolveComponent<INewGameLoader>(boardType);
        }
    }
}