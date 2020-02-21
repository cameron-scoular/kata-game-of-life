using System;
using System.Collections.Generic;
using System.IO;
using kata_game_of_life;
using kata_game_of_life.Board;
using kata_game_of_life.BoardLoaders;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Persistence;
using kata_game_of_life.Processors;
using kata_game_of_life.State;
using Newtonsoft.Json;
using Xunit;
using Moq;

namespace kata_game_of_life_tests
{
    public class LocalGamePersistenceShould
    {
        public string TestFileName = "test.life";
        
        [Fact]
        public void SaveAndLoad_GameLoads2DCorrectly_AfterSaving()
        {
            var gameStateToSave = new GameState(new TwoDimensionalBoard(new List<int>(){5, 5}), new DefaultBoardProcessor(new RuleSet("2333")));

            var expectedLoadedGameStateString = JsonConvert.SerializeObject(gameStateToSave);

            var mockBoardLoaderFactory = GetMockBoardLoaderFactory();
            
            var localGamePersistence = new LocalGamePersistence(mockBoardLoaderFactory.Object, "");
            localGamePersistence.SaveGame(gameStateToSave, TestFileName);
            var loadedGameState = localGamePersistence.LoadGame(TestFileName);
            
            Assert.Equal(expectedLoadedGameStateString, JsonConvert.SerializeObject(loadedGameState));
            
            File.Delete($"{TestFileName}");
        }

        [Fact]
        public void FileIsPersistent_ReturnsTrue_AfterSaving()
        {
            var gameStateToSave = new GameState(new TwoDimensionalBoard(new List<int>(){5, 5}), new DefaultBoardProcessor(new RuleSet("2333")));

            var expectedLoadedGameStateString = JsonConvert.SerializeObject(gameStateToSave);

            var mockBoardLoaderFactory = GetMockBoardLoaderFactory();

            var localGamePersistence = new LocalGamePersistence(mockBoardLoaderFactory.Object, "");
            localGamePersistence.SaveGame(gameStateToSave, TestFileName);
            
            Assert.True(localGamePersistence.FileHasBeenSaved(TestFileName));
            
            File.Delete($"{TestFileName}");
        }
        
        [Fact]
        public void FileIsPersistent_ReturnsFalse_OnNonexistentFile()
        {
            var mockBoardLoaderFactory = GetMockBoardLoaderFactory();

            var localGamePersistence = new LocalGamePersistence(mockBoardLoaderFactory.Object, "");
         
            Assert.False(localGamePersistence.FileHasBeenSaved("yeet.txt"));
        }
        
        private Mock<ILoaderFactory> GetMockBoardLoaderFactory()
        {
            var mockBoardLoaderFactory = new Mock<ILoaderFactory>();
            mockBoardLoaderFactory.Setup(x => x.CreateBoardLoader(It.IsAny<Type>()))
                .Returns(new TwoDimensionalBoardLoader());
            
            mockBoardLoaderFactory.Setup(x => x.CreateBoardProcessorLoader())
                .Returns(new BoardProcessorLoader());

            return mockBoardLoaderFactory;
        }

        
    }
}