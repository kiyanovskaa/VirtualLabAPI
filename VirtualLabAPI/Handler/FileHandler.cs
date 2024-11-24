using System.Text.Json;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Handler
{
    public class FileHandler<T>
    {
        public static void WriteToFile<T>(List<T> data, string filePath)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        static public List<T> ReadFromFile(string path)
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<T>();
            }

            try
            {
                var json = System.IO.File.ReadAllText(path);

                var items = JsonSerializer.Deserialize<List<T>>(json);
               

                return items;
            }
            catch (JsonException)
            {
                return new List<T>();
            }
            catch (IOException ex)
            {
                return new List<T>();
            }
        }


    }
}
