using System;
using kata_game_of_life.Interfaces;

namespace kata_game_of_life.Renderer
{
    public class GameRendererFactory : IGameRendererFactory
    {
        public IGameRenderer CreateGameRenderer(Type boardType)
        {

            var componentRegister = ComponentRegister.GetComponentRegisterInstance();

            return componentRegister.ResolveComponent<IGameRenderer>(boardType);

        }
    }
}