namespace kata_game_of_life
{
    public interface IBoardPersistence
    {
        Cell[,] LoadBoardState(string path);
        void SaveBoardState(Cell[,] board, string path);
    }
}