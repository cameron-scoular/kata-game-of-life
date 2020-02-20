using System;

namespace kata_game_of_life.Interfaces
{
    public interface IGameRendererFactory
    {
        IGameRenderer CreateGameRenderer(Type boardType);
    }
}