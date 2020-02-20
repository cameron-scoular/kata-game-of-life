namespace kata_game_of_life.Persistence
{
    public class PersistedGameState
    {

        public string BoardType { get; set; }
        public string BoardProcessorType { get; set; }
        public RuleSet RuleSet { get; set; }
        public int TickNumber { get; set; }
        public object CellArray { get; set; }

    }
}