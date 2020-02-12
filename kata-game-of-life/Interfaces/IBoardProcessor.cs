namespace kata_game_of_life
{
    public interface IBoardProcessor
    {

        Cell[,] GetNextBoard(Cell[,] board);

    }
}