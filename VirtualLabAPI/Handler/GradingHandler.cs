﻿using System.Text.Json;
using VirtualLabAPI.Models;
using Newtonsoft.Json;
namespace VirtualLabAPI.Handler
{
    static public class GradingHandler
    {
        private const string FilePath = "E:\\pz4_1\\VirtualLabWebApi\\VirtualLabAPI\\VirtualLabAPI\\Source\\Diagrams.txt";
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

                        var json1 = JsonConvert.SerializeObject(cl);
                        var json2 = JsonConvert.SerializeObject(foundClassStudent);

                        return json1 == json2;
                    }
                    else
                    {
                        return false;
                        //----
                    }
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