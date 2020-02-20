using kata_game_of_life.State;

namespace kata_game_of_life.Interfaces
{
    public interface IBoardProcessor
    {

        IBoard GetNextBoard(IBoard board);
        
        RuleSet RuleSet { get;}
    }
}