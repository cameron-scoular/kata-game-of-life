using System;
using System.IO;
using kata_game_of_life.Interfaces;
using Newtonsoft.Json;

namespace kata_game_of_life
{
    public class LocalBoardPersistence : IBoardPersistence
    {

        public T LoadBoardState <T> (string fileName)
        {
            var path = $"{Configuration.DefaultSaveDirectory}{fileName}";
            var board = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(board);
        }
        
        public void SaveBoardState <T>(T board, string fileName)
        {
            var path = $"{Configuration.DefaultSaveDirectory}{fileName}";
            
            File.WriteAllTextAsync(path, JsonConvert.SerializeObject(board));
        }

    }
}