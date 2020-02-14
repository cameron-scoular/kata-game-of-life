namespace kata_game_of_life.Interfaces
{
    public interface IBoardProcessor
    {

        IBoard GetNextBoard(IBoard board);

    }
}