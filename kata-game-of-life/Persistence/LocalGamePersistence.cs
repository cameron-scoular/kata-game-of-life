using System;
using System.IO;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;
using Newtonsoft.Json;

namespace kata_game_of_life.Persistence
{
    public class LocalGamePersistence : IGamePersistence
    {
        private readonly ILoaderFactory _loaderFactory;
        private readonly string _saveDirectory;

        public LocalGamePersistence(ILoaderFactory loaderFactory, string saveDirectory)
        {
            _loaderFactory = loaderFactory;
            _saveDirectory = saveDirectory;
        }
        
        public GameState LoadGame(string fileName)
        {
            var fileNameWithExtension = AddFileNameExtension(fileName);
            
            return LoadPersistedGame(fileNameWithExtension);
        }
        
        private GameState LoadPersistedGame(string fileName)
        {
            var persistedGameState = ReadPersistedGameState(fileName);

            var boardType = Type.GetType(persistedGameState.BoardType);
            var boardLoaderType = Type.GetType(persistedGameState.BoardProcessorType);

            var boardLoader = _loaderFactory.CreateBoardLoader(boardType);
            var board = boardLoader.LoadBoard(persistedGameState.CellArray);

            var boardProcessorLoader = _loaderFactory.CreateBoardProcessorLoader();
            var boardProcessor = boardProcessorLoader.LoadBoardProcessor(persistedGameState.RuleSet, boardLoaderType);

            return new GameState(board, boardProcessor)
            {
                TickNumber = persistedGameState.TickNumber
            };
        }
        
        public void SaveGame(GameState gameState, string fileName)
        {
            var fileNameWithExtension = AddFileNameExtension(fileName);
            
            var persistedBoardState = new PersistedGameState()
            {
                BoardType = gameState.Board.GetType().ToString(),
                BoardProcessorType = gameState.BoardProcessor.GetType().ToString(),
                RuleSet = gameState.BoardProcessor.RuleSet,
                TickNumber = gameState.TickNumber,
                CellArray = gameState.Board.GetCellArray()
            };
            
            WritePersistedGameState(persistedBoardState, fileNameWithExtension);
        }
        
        public bool FileIsSaveFile(string fileName)
        {
            var fileNameWithExtension = AddFileNameExtension(fileName);

            try
            {
                LoadPersistedGame(fileNameWithExtension);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private PersistedGameState ReadPersistedGameState (string loadFileName)
        {
            var path = $"{_saveDirectory}{loadFileName}";
            var board = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<PersistedGameState>(board);
        }
        
        private void WritePersistedGameState (PersistedGameState persistedGameState, string saveFileName)
        {
            var path = $"{_saveDirectory}{saveFileName}";
            
            File.WriteAllText(path, JsonConvert.SerializeObject(persistedGameState));
        }
        
        private static string AddFileNameExtension(string fileName)
        {
            var loadFileName = fileName;

            if (fileName.EndsWith(".nlife"))
            {
                loadFileName.Remove(loadFileName.Length - 5);
            }
            
            if (!loadFileName.EndsWith(".life"))
            {
                loadFileName += ".life";
            }

            return loadFileName;
        }

    }
}