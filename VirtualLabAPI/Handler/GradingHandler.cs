using System.Text.Json;
using VirtualLabAPI.Models;
using Newtonsoft.Json;

namespace VirtualLabAPI.Handler
{
    static public class GradingHandler
    {
        private const string FilePath = "E:\\pz4_1\\VirtualLabWebApi\\VirtualLabAPI\\VirtualLabAPI\\Source\\Diagrams.txt";
        static public int Evaluate(List<Class> studentClasses, int id)
        {
            try
            {
                List<Diagram> diagrams = FileHandler<Diagram>.ReadFromFile(FilePath);
                if (diagrams == null)
                {
                    Console.WriteLine("Failed to deserialize JSON.");
                    return 0;
                }

                // Шукаємо діаграму з відповідним ID
                var diagram = diagrams.FirstOrDefault(d => d.Id == id);

                if (diagram == null)
                {
                    Console.WriteLine($"Diagram with ID {id} not found.");
                    return 0;
                }

                // Отримуємо список класів з цієї діаграми
                var classes = diagram.classes;
                int Errors = 0;
                foreach (var cl in classes)
                {
                    var foundClassStudent = studentClasses.FirstOrDefault(c => c.Name == cl.Name);

                    // Перевіряємо, чи знайдено об'єкт
                    if (foundClassStudent != null)
                    {
                        if (cl == null || foundClassStudent == null) return 0;

                        if (cl.Name != foundClassStudent.Name || !cl.attributes.SequenceEqual(foundClassStudent.attributes) || !cl.methods.SequenceEqual(foundClassStudent.methods))
                        {
                            // Дії, якщо хоч одне з полів відрізняється
                            Errors++;
                        }
                       
                        for (int i = 0; i < cl.relatedClasses.Count; i++)
                        {
                            if (i >= foundClassStudent.relatedClasses.Count) //буде додавати 1 за кожен відсутній relatedclass в студентському блочку
                            {
                                Errors ++; // Відсутній словник
                                continue;
                            }
                            //if (cl.relatedClasses.Count != foundClassStudent.relatedClasses.Count)
                            //{
                            //    int a = Math.Abs(cl.relatedClasses.Count - foundClassStudent.relatedClasses.Count);
                            //    Errors += a;
                            //}


                            var dict1 = cl.relatedClasses[i];
                            var dict2 = foundClassStudent.relatedClasses[i];

                            // Перевіряємо відповідність ключів і значень
                            foreach (var kvp1 in dict1)
                            {
                                if (!dict2.TryGetValue(kvp1.Key, out var value2))
                                {
                                    Errors++; // Ключ відсутній у словнику 2
                                }
                                else if (kvp1.Value != value2)
                                {
                                    Errors++; // Значення не збігаються
                                }
                            }

                            // Перевіряємо, чи у словнику 2 є додаткові ключі
                            //foreach (var kvp2 in dict2)
                            //{
                            //    if (!dict1.ContainsKey(kvp2.Key))
                            //    {
                            //        Errors++; // Додатковий ключ у словнику 2
                            //    }
                            //}
                        }
                        if(cl.relatedClasses.Count< foundClassStudent.relatedClasses.Count)
                        {
                            Errors += (foundClassStudent.relatedClasses.Count - cl.relatedClasses.Count);
                        }
                        //код тут
                    }
                    else
                    {
                        return 100;
                        //----
                    }
                }

                return Errors;


                // Логіка оцінювання (замість цього можете додати свою перевірку)
                Console.WriteLine($"Found {classes.Count} classes in diagram with ID {id}.");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading or processing the file: {ex.Message}");
                return 0;
            }

        }

    }
}
