using System.Text.Json;
using VirtualLabAPI.Models;
using Newtonsoft.Json;
namespace VirtualLabAPI.Handler
{
    static public class GradingHandler
    {
        private const string FilePath = "E:\\Study\\Uni\\VLPZ\\VirtualLabAPI\\VirtualLabAPI\\Source\\Diagrams.txt";
        static public bool Evaluate(List<Class> studentClasses, int id)
        {
            try
            {
                List<Diagram> diagrams = FileHandler<Diagram>.ReadFromFile(FilePath);
                if (diagrams == null)
                {
                    Console.WriteLine("Failed to deserialize JSON.");
                    return false;
                }

                // Шукаємо діаграму з відповідним ID
                var diagram = diagrams.FirstOrDefault(d => d.Id == id);

                if (diagram == null)
                {
                    Console.WriteLine($"Diagram with ID {id} not found.");
                    return false;
                }

                // Отримуємо список класів з цієї діаграми
                var classes = diagram.classes;

                foreach (var cl in classes)
                {
                    var foundClassStudent = studentClasses.FirstOrDefault(c => c.Name == cl.Name);


                    // Перевіряємо, чи знайдено об'єкт
                    if (foundClassStudent != null)
                    {
                        if (cl == null || foundClassStudent == null) return false;

                        if (!(cl.Name == foundClassStudent.Name &&
                           cl.attributes != null && foundClassStudent.attributes != null &&
                           cl.attributes.SequenceEqual(foundClassStudent.attributes) &&
                           cl.methods != null && foundClassStudent.methods != null &&
                           cl.methods.SequenceEqual(foundClassStudent.methods)))
                            return false; // Поля без `relatedClasses` не збігаються
                    }

                    if (cl.relatedClasses != null && foundClassStudent.relatedClasses != null &&
                        cl.relatedClasses.Count == foundClassStudent.relatedClasses.Count)
                    {
                        for (int i = 0; i < cl.relatedClasses.Count; i++)
                        {
                            var dict1 = cl.relatedClasses[i];
                            var dict2 = foundClassStudent.relatedClasses[i];

                            // Порівнюємо ключі та відповідні значення
                            if (!dict1.Keys.OrderBy(k => k).SequenceEqual(dict2.Keys.OrderBy(k => k)))
                            {
                                return false; // Ключі не збігаються
                            }
                            foreach (var key in dict1.Keys)
                            {
                                if (!dict2.TryGetValue(key, out var value2) || dict1[key] != value2)
                                {
                                    return false; // Значення для ключа не збігаються
                                }
                            }
                        }

                    }
                    return true;

                }


                // Логіка оцінювання (замість цього можете додати свою перевірку)
                Console.WriteLine($"Found {classes.Count} classes in diagram with ID {id}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading or processing the file: {ex.Message}");
                return false;
            }

        }

    }
}
