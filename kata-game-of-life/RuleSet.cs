namespace kata_game_of_life
{
    public class RuleSet
    {
        public RuleSet(int intendedDimensionCount, string ruleString)
        {
            IntendedDimensionCount = intendedDimensionCount;
            RuleString = ruleString;
            AliveToAliveLowerBound = int.Parse(ruleString[0].ToString());
            AliveToAliveUpperBound = int.Parse(ruleString[1].ToString());
            DeadToAliveLowerBound = int.Parse(ruleString[2].ToString());
            DeadToAliveUpperBound = int.Parse(ruleString[3].ToString());
        }
        
        public int IntendedDimensionCount { get; set; }
        public string RuleString { get; set; }
        
        public int AliveToAliveLowerBound { get; set; }
        public int DeadToAliveUpperBound { get; set; }
        public int DeadToAliveLowerBound { get; set; }
        public int AliveToAliveUpperBound { get; set; }

    }
}