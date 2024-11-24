using System.Text.Json;
using VirtualLabAPI.Models;
using Newtonsoft.Json;
using VirtualLabAPI.Controllers;

namespace VirtualLabAPI.Handler
{
     public class GradingHandler : IGradingHandler
    {
        private const string FilePath = "E:\\pz4_1\\VirtualLabWebApi\\VirtualLabAPI\\VirtualLabAPI\\Source\\Diagrams.txt";
        private const string FilePath2 = "E:\\pz4_1\\VirtualLabWebApi\\VirtualLabAPI\\VirtualLabAPI\\Source\\Tasks.txt";
        static public int Evaluate(List<Class> studentClasses, int id)
        {
            return 0;

        }


        public static int CalculateStudentGrade(int Errornum , int diagramId, int num) 
        {

            List<Assignement> tasks = FileHandler<Assignement>.ReadFromFile(FilePath2);
            var task = tasks?.Find(t => t.Id == diagramId);
            //
            int maxGrade = task.MaxGrade;
            int per = maxGrade / num;
            int result = maxGrade - per * Errornum;
            Console.WriteLine(result);
            return result;
        }

        public int Update(Diagram diagFromStudent)
        {
            try
            {

                List<Class> studentClasses = diagFromStudent.classes;
                int id = diagFromStudent.Id;
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
                int num = 0;
                foreach (var cl in classes)
                {
                    num += cl.relatedClasses.Count + 1;

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
                                Errors++; // Відсутній словник
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

                        }
                        if (cl.relatedClasses.Count < foundClassStudent.relatedClasses.Count)
                        {
                            Errors += (foundClassStudent.relatedClasses.Count - cl.relatedClasses.Count);
                        }
                        //код тут
                    }
                    else
                    {
                        Errors += 2;
                        //----
                    }
                    return true;

                }

                int res= CalculateStudentGrade(Errors, diagram.Id, num);
                TaskHandler.UpdateTask(res, diagram.Id);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading or processing the file: {ex.Message}");
                return 0;
            }
        }
    }
}
