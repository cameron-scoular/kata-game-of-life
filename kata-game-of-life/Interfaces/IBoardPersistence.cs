namespace kata_game_of_life
{
    public interface IBoardPersistence
    {
        T LoadBoardState<T>(string path);
        void SaveBoardState<T>(T board, string path);
    }
}