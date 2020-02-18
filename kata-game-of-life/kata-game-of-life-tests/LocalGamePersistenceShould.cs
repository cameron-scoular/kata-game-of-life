using System.IO;
using kata_game_of_life;
using kata_game_of_life.Boards;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;
using kata_game_of_life.State;
using Newtonsoft.Json;
using Xunit;

namespace kata_game_of_life_tests
{
    public class LocalGamePersistenceShould
    {
        public string TestFileName = "test.life";
        
        [Fact]
        public void SaveAndLoad_GameLoads2DCorrectly_AfterSaving()
        {
            var gameStateToSave = new GameState(new TwoDimensionalBoard(), new DefaultBoardProcessor("2333"));

            var expectedLoadedGameStateString = JsonConvert.SerializeObject(gameStateToSave);
            var localGamePersistence = new LocalGamePersistence();
            localGamePersistence.SaveGame(gameStateToSave, TestFileName);
            var loadedGameState = localGamePersistence.LoadGame(TestFileName);
            
            Assert.Equal(expectedLoadedGameStateString, JsonConvert.SerializeObject(loadedGameState));
            
            File.Delete($"{Configuration.DefaultSaveDirectory}{TestFileName}");
        }

        [Fact]
        public void FileIsPersistent_ReturnsTrue_AfterSaving()
        {
            var gameStateToSave = new GameState(new TwoDimensionalBoard(), new DefaultBoardProcessor("2333"));

            var expectedLoadedGameStateString = JsonConvert.SerializeObject(gameStateToSave);
            var localGamePersistence = new LocalGamePersistence();
            localGamePersistence.SaveGame(gameStateToSave, TestFileName);
            
            Assert.True(localGamePersistence.FileIsPersistent(TestFileName));
            
            File.Delete($"{Configuration.DefaultSaveDirectory}{TestFileName}");
        }
        
        [Fact]
        public void FileIsPersistent_ReturnsFalse_OnNonexistentFile()
        {
            var localGamePersistence = new LocalGamePersistence();
         
            Assert.False(localGamePersistence.FileIsPersistent("yeet.txt"));
        }
        
        
        
    }
}