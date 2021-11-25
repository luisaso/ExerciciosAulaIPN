namespace Exercicio2LINQ
{
    public class UserTasksWithDate
    {
        public User User { get; set; }
        public IEnumerable<TaskWithDate> TaskList { get; set; }

        public override string ToString()
        {
            string output = $"{User.FirstName} {User.LastName} - {User.Role}";
            bool hasTask = false;
            foreach (var task in TaskList)
            {
                if (task.DueDate.Date >= DateTime.Now.Date.AddDays(2))
                {
                    output += $"\n\t- {task.Title}: {task.DueDate.Date}";
                    hasTask = true;
                }

            }
            if (!hasTask)
            {
                output += "\nAll tasks are late.";
            }
            output += "\n";

            return output;
        }
    }
}