namespace Exercicio2LINQ
{
    public class UserTasks
    {
        public User User { get; set; }
        public IEnumerable<Task> TaskList { get; set; }

        public override string ToString()
        {
            string output = $"{User.FirstName} {User.LastName} - {User.Role}";

            foreach (var task in TaskList)
            {
                output += $"\n\t- {task.Title}";
            }
            output += "\n";

            return output;
        }
    }
    public class UserTasksDate : UserTasks
    {
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            string output = $"{User.FirstName} {User.LastName} - {User.Role}";
            bool hasTask = false;
            foreach (var task in TaskList)
            {
                if (DueDate.Date >= DateTime.Now.Date)
                {
                    output += $"\n\t- {task.Title}: {DueDate.Date}";
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
