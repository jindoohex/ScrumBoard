using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.util
{
    public class JsonFileReader
    {
        public static List<T> ReadJsonGeneric<T>(string fileName)
        {
            /*
             * If run first time, and no file exist, it will create a file with an empty list
             */
            if (!File.Exists(fileName))
            {
                JsonFileWriter.WriteToJsonGeneric(new List<T>(), fileName);
            }

            using (var jReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<T>>(jReader.ReadToEnd());
            }
        }
        public static List<UserStory> ReadJson(string fileName)
        {
            /*
             * If run first time, and no file exist, it will create a file with an empty list
             */
            if (!File.Exists(fileName))
            {
                JsonFileWriter.WriteToJson(new List<UserStory>(), fileName);
            }

            using (var jReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<UserStory>>(jReader.ReadToEnd());
            }
        }
    }
}
