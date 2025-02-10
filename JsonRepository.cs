using System;
using System.IO;
using System.Text.Json;

namespace LibrarySystem.Repositories
{
    public class JsonRepository<T>
    {
        public void SaveToFile(T data, string filePath)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public T LoadFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
