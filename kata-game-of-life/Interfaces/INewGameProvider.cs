using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface INewGameProvider
    {
        GameState LoadNewGame(Arguments args);
    }
}