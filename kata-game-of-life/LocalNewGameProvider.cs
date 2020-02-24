using System;
using System.IO;
using System.Linq;
using kata_game_of_life.Interfaces;
using kata_game_of_life.Processors;
using kata_game_of_life.State;

namespace kata_game_of_life
{
    public class LocalNewGameProvider : INewGameProvider
    {
        private readonly ILoaderFactory _loaderFactory;
        private INewGameLoader _newGameLoader;

        public LocalNewGameProvider(ILoaderFactory loaderFactory)
        {
            _loaderFactory = loaderFactory;
        }

        public GameState LoadNewGame(Arguments arguments)
        {
            if (LoadingArgumentsAreNotSpecified(arguments))
            {
                return LoadDefaultNewGameState(arguments);
            }
            
            var dimensionCount = GetNewGameFileDimensionCount(arguments.LoadFileName);

            var boardType = Configuration.DefaultBoards[dimensionCount];

            _newGameLoader = _loaderFactory.CreateNewGameLoader(boardType);

            return _newGameLoader.LoadNewGame(arguments.LoadFileName);

        }
        
        private static bool LoadingArgumentsAreNotSpecified(Arguments arguments)
        {
            return arguments.DefaultDimensions.Count > 0 || arguments.LoadFileName == null || arguments.LoadFileName == string.Empty;
        }
        
        private GameState LoadDefaultNewGameState(Arguments arguments)
        {
            var boardRules = Configuration.DefaultRuleSets.First(r => r.Key == arguments.DefaultDimensions.Count);
            var boardType = Configuration.DefaultBoards.First(t => t.Key == arguments.DefaultDimensions.Count).Value;
            var ruleSet = boardRules.Value;

            var board = (IBoard)Activator.CreateInstance(boardType, arguments.DefaultDimensions);
            
            return new GameState(board, new DefaultBoardProcessor(ruleSet));
        }

        private int GetNewGameFileDimensionCount(string fileName)
        {
            fileName = AddFileNameExtension(fileName);
            var path = $"{Configuration.DefaultNewDirectory}{fileName}";
            return int.Parse(File.ReadLines(path).First());
        }
        
        public static string AddFileNameExtension(string fileName)
        {
            var loadFileName = fileName;

            if (!loadFileName.EndsWith(".nlife"))
            {
                loadFileName += ".nlife";
            }

            return loadFileName;
        }
    }
}