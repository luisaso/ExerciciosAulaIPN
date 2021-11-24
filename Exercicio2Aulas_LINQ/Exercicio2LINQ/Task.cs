using Newtonsoft.Json;
using System.Text;

namespace MyNamespace
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AssignedTo { get; set; }

        public static List<Task> ReadJSON()
        {
            string fileName = @"C:\Users\lcspa\Desktop\IT_Academy\Exercicio_aula\Exercicio2Aulas_LINQ\Exercicio2LINQ\tasks.json";
            //StringBuilder jsonString = new(File.ReadAllText(fileName));
            string jsonString = File.ReadAllText(fileName);

            var tasks = JsonConvert.DeserializeObject<List<Task>>(jsonString);
            return tasks;
        }

        public override string ToString()
        {
            string output = $"- {Title}";
            return output;
        }
    }

    public class TaskWithDate : Task
    {
        public DateTime Date { get; set; }

        public static List<TaskWithDate> ReadJSONWithDate()
        {
            string fileName = @"C:\Users\lcspa\Desktop\IT_Academy\Exercicio_aula\Exercicio2Aulas_LINQ\Exercicio2LINQ\tasks2.json";
            string jsonString = File.ReadAllText(fileName);

            var rawTasks = JsonConvert.DeserializeObject<List<TaskWithDate>>(jsonString);
            var tasks = new List<TaskWithDate>();
            foreach (var task in rawTasks)
            {
                
            }
            return tasks;
        }
        public Date
    }
}