using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Exercicio2LINQ
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AssignedTo { get; set; }

        public static List<Task> ReadJSON()
        {
            string fileName = @"tasks.json";
            //StringBuilder jsonString = new(File.ReadAllText(fileName));
            string jsonString = File.ReadAllText(fileName);

            var tasks = JsonConvert.DeserializeObject<List<Task>>(jsonString);
            return tasks;
        }

        public override string ToString()
        {
            string output = $"\t- {Title}";
            return output;
        }
    }

    public class TaskWithDate : Task
    {
        public DateTime DueDate { get; set; }

        public static List<TaskWithDate> ReadJSONWithDate()
        {
            string fileName = @"tasks2.json";
            string jsonString = File.ReadAllText(fileName);

            var rawTasks = JsonConvert.DeserializeObject<List<TaskWithDate>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" });

            return rawTasks;
        }
        public DateTime ConvertDateFromString(string date)
        {
            DateTime myDate = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return myDate;
        }
    }
}

