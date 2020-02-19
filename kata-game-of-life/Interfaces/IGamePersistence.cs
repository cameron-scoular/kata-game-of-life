using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface IGamePersistence
    {
        GameState LoadGame(string path);
        void SaveGame(GameState gameState, string fileName);

        bool FileHasBeenSaved(string fileName);
    }
}