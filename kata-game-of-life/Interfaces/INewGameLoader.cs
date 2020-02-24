using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface INewGameLoader
    {
        GameState LoadNewGame(string fileName);
    }
}