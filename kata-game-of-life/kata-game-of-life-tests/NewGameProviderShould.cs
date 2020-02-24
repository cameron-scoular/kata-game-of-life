using System;
using System.Collections.Generic;
using kata_game_of_life;
using kata_game_of_life.BoardLoaders;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Persistence;
using Moq;
using Xunit;

namespace kata_game_of_life_tests
{
    public class NewGameProviderShould
    {

        [Fact]
        public void LoadNewGame_ShouldLoad2DRandomDefaultGame_GivenDefault2DArguments()
        {

            var loaderFactory = new Mock<ILoaderFactory>();
            loaderFactory.Setup(x => x.CreateNewGameLoader(It.IsAny<Type>())).Returns(new TwoDimensionalNewGameLoader());
                
            var newGameProvider = new LocalNewGameProvider(loaderFactory.Object);

            var args = new Arguments()
            {
                DefaultDimensions = new List<int>() {10, 9}
            };

            var gameState = newGameProvider.LoadNewGame(args);
            
            Assert.True(gameState.Board.GetDimensions()[0] == 10);
            Assert.True(gameState.Board.GetDimensions()[1] == 9);

        }
        
        [Fact]
        public void LoadNewGame_ShouldLoad3DRandomDefaultGame_GivenDefault3DArguments()
        {

            var loaderFactory = new Mock<ILoaderFactory>();
            loaderFactory.Setup(x => x.CreateNewGameLoader(It.IsAny<Type>())).Returns(new ThreeDimensionalNewGameLoader());
                
            var newGameProvider = new LocalNewGameProvider(loaderFactory.Object);

            var args = new Arguments()
            {
                DefaultDimensions = new List<int>() {10, 5, 3}
            };

            var gameState = newGameProvider.LoadNewGame(args);
            
            Assert.True(gameState.Board.GetDimensions()[0] == 10);
            Assert.True(gameState.Board.GetDimensions()[1] == 5);
            Assert.True(gameState.Board.GetDimensions()[2] == 3);

        }

        [Fact]
        public void LoadNewGame_ShouldLoadTest2DGame_GivenLoadFileArgument()
        {
            var loaderFactory = new Mock<ILoaderFactory>();
            loaderFactory.Setup(x => x.CreateNewGameLoader(It.IsAny<Type>())).Returns(new TwoDimensionalNewGameLoader());
                
            var newGameProvider = new LocalNewGameProvider(loaderFactory.Object);

            var args = new Arguments()
            {
                DefaultDimensions = new List<int>(),
                LoadFileName = "test2D.nlife"
            };

            var gameState = newGameProvider.LoadNewGame(args);
            
            Assert.True(gameState.Board.GetDimensions()[0] == 3);
            Assert.True(gameState.Board.GetDimensions()[1] == 2);

        }
        
        [Fact]
        public void LoadNewGame_ShouldLoadTest3DGame_GivenLoadFileArgument()
        {
            var loaderFactory = new Mock<ILoaderFactory>();
            loaderFactory.Setup(x => x.CreateNewGameLoader(It.IsAny<Type>())).Returns(new ThreeDimensionalNewGameLoader());
                
            var newGameProvider = new LocalNewGameProvider(loaderFactory.Object);

            var args = new Arguments()
            {
                DefaultDimensions = new List<int>(),
                LoadFileName = "test3D.nlife"
            };

            var gameState = newGameProvider.LoadNewGame(args);
            
            Assert.True(gameState.Board.GetDimensions()[0] == 3);
            Assert.True(gameState.Board.GetDimensions()[1] == 2);
            Assert.True(gameState.Board.GetDimensions()[2] == 2);

        }
        
    }
}