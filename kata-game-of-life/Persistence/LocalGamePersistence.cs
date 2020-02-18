using System;
using System.IO;
using kata_game_of_life.Interfaces;
using kata_game_of_life.State;
using Newtonsoft.Json;

namespace kata_game_of_life.Persistence
{
    public class LocalGamePersistence : IGamePersistence
    {
        public GameState LoadGame(string fileName)
        {
            var fileNameWithExtension = AddFileNameExtension(fileName);
            
            return LoadPersistedGame(fileNameWithExtension);
        }
        
        private GameState LoadPersistedGame(string fileName)
        {
            var persistedGameState = LoadSavedPersistedGameState(fileName);

            var boardType = Type.GetType(persistedGameState.BoardType);
            var boardProcessorType = Type.GetType(persistedGameState.BoardProcessorType);

            var loadBoardFunction = TypeLoader.BoardLoaderMappings[boardType];
            var board = loadBoardFunction(persistedGameState.CellArray);

            var dimensions = board.GetDimensions().Count;

            var loadBoardProcessorFunction = TypeLoader.BoardProcessorMappings[boardProcessorType];
            var boardProcessor = loadBoardProcessorFunction(dimensions);

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
                TickNumber = gameState.TickNumber,
                CellArray = gameState.Board.GetCellArray()
            };
            
            SaveGameState(persistedBoardState, fileNameWithExtension);
        }
        
        public bool FileIsPersistent(string fileName)
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


        private PersistedGameState LoadSavedPersistedGameState (string loadFileName)
        {
            var path = $"{Configuration.DefaultSaveDirectory}{loadFileName}";
            var board = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<PersistedGameState>(board);
        }
        
        private void SaveGameState (PersistedGameState persistedGameState, string saveFileName)
        {
            var path = $"{Configuration.DefaultSaveDirectory}{saveFileName}";
            
            File.WriteAllTextAsync(path, JsonConvert.SerializeObject(persistedGameState));
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