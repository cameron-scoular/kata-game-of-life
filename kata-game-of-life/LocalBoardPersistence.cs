using System;
using System.IO;
using Newtonsoft.Json;

namespace kata_game_of_life
{
    public class LocalBoardPersistence : IBoardPersistence
    {

        public T LoadBoardState <T> (string path)
        {
            var board = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(board);
        }
        
        public void SaveBoardState <T>(T board, string path)
        {
            File.WriteAllTextAsync(path, JsonConvert.SerializeObject(board));
        }

    }
}