namespace kata_game_of_life
{
    public interface IBoardProcessor
    {

        IBoard GetNextBoard(IBoard board);

    }
}