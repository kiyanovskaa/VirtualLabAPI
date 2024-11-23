using System.Text.Json;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Handler
{
    static public class FileHandler<T>
    {
        static public List<T> ReadFromFile(string path)
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<T>();
            }

            try
            {
                // Зчитуємо JSON з файлу
                var json = System.IO.File.ReadAllText(path);

                // Десеріалізуємо JSON у список StarterDiagram
                var items = JsonSerializer.Deserialize<List<T>>(json);

                // Знаходимо діаграму за ID
               

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
