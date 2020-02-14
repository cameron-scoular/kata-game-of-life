namespace kata_game_of_life.Interfaces
{
    public interface IBoardPersistence
    {
        T LoadBoardState<T>(string path);
        void SaveBoardState<T>(T board, string path);
    }
}