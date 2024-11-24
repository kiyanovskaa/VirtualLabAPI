using System.Diagnostics;
using System.Threading.Tasks;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Handler
{
    public class TaskHandler
    {
        private static readonly string FilePath2 = Path.Combine(Directory.GetCurrentDirectory(), "Source", "Tasks.txt");

        static public void UpdateTask(int Grade, int TaskId)
        {
            List<Assignement> tasks = FileHandler<Assignement>.ReadFromFile(FilePath2);
            if (tasks == null || tasks.Count == 0)
            {
                Console.WriteLine("No tasks found in the file.");
                return;
            }

            // Знаходимо завдання за TaskId
            var taskToUpdate = tasks.FirstOrDefault(t => t.Id == TaskId);

            if (taskToUpdate == null)
            {
                Console.WriteLine($"Task with ID {TaskId} not found.");
                return;
            }

            // Оновлюємо поле Grade
            taskToUpdate.Grade = Grade;
            taskToUpdate.isDone = true;

            // Перезаписуємо файл оновленим списком завдань
            FileHandler<Assignement>.WriteToFile(tasks, FilePath2);

            Console.WriteLine($"Task with ID {TaskId} successfully updated with grade {Grade}.");
        }
    }
}