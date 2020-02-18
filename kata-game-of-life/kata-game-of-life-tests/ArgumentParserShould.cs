using System.Collections.Generic;
using kata_game_of_life;
using Newtonsoft.Json;
using Xunit;

namespace kata_game_of_life_tests
{
    public class ArgumentParserShould
    {

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {"-s testsave.life", new Arguments()
            {
                DefaultDimensions = 0,
                LoadFileName = null,
                SaveFileName = "testsave.life"
            }},
            new object[] {"-s testsave.life -l testload.life", new Arguments()
            {
                DefaultDimensions = 0,
                LoadFileName = "testload.life",
                SaveFileName = "testsave.life"
            }},
            new object[] {"-d 2", new Arguments()
            {
                DefaultDimensions = 2,
                LoadFileName = null,
                SaveFileName = null
            }},
            new object[] {"-d 2 -d 3", new Arguments()
            {
                DefaultDimensions = 2,
                LoadFileName = null,
                SaveFileName = null
            }},
        };
        
        
        [Theory]
        [MemberData(nameof(Data))]
        public void ParseArgument_ReturnsCorrect_Object_GivenDefaultArgument(string input, Arguments expectedArguments)
        {
            var args = ArgumentParser.ParseArguments(input.Split(" "));
            
            Assert.Equal(JsonConvert.SerializeObject(expectedArguments), JsonConvert.SerializeObject(args));
        }
    }
}