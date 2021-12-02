namespace Exercicio2LINQ
{
    public partial class MyProgram
    {
        public static void Main(string[] args)
        {
            List<User> users = User.ReadJSON();
            List<Task> tasks = Task.ReadJSON();
            List<TaskWithDate> tasksWithDate = TaskWithDate.ReadJSONWithDate();

            ////Sem LINQ
            WriteWithoutLINQ(users, tasks);

            ////Com LINQ - Query Syntax
            WriteWithSyntaxLINQ(users, tasks);

            ////Com LINQ - Method Syntax
            WriteWithMethodLINQ(users, tasks);

            //Exercicio Extra
            WriteWithSyntaxLINQAndDate(users, tasksWithDate);
        }

        private static void WriteWithSyntaxLINQAndDate(List<User> users, List<TaskWithDate> tasksWithDate)
        {
            //Código que era preciso mas descobri uma forma melhor de o fazer sem ter de converter de string para DateTime
            //List<TaskWithDate> tasksWithDateTime = new();
            //foreach (var taskWithDateString in tasksWithDateString)
            //{
            //    var timeConverted = taskWithDateString.ConvertDateFromString(taskWithDateString.DueDate);

            //    tasksWithDateTime.Add(new TaskWithDate<DateTime>()
            //    {
            //        AssignedTo = taskWithDateString.AssignedTo,
            //        Id = taskWithDateString.Id,
            //        Title = taskWithDateString.Title,
            //        DueDate = timeConverted
            //    });
            //}
            Console.WriteLine();
            Console.WriteLine("\n-----------Com recurso a LINQ - Query Syntax E Data-----------");
            Console.WriteLine();
            var query = from taskWithDate in tasksWithDate
                        orderby taskWithDate.DueDate
                        group taskWithDate by taskWithDate.AssignedTo into tasksList
                        join user in users on tasksList.FirstOrDefault().AssignedTo equals Int32.Parse(user.Id)
                        select new UserTasksWithDate()
                        {
                            User = user,
                            TaskList = tasksList
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void WriteWithMethodLINQ(List<User> users, List<Task> tasks)
        {
            Console.WriteLine();
            Console.WriteLine("\n-----------Com recurso a LINQ - Method Syntax-----------");
            Console.WriteLine();
            //List<User> userListM = users.Select(user => user).ToList();

            //foreach (var user in userListM)
            //{
            //    Console.WriteLine(user.ToString());
            //    List<Task> taskList = tasks.Where(task => task.AssignedTo.Equals(Int32.Parse(user.Id))).ToList();
            //    foreach (var task in taskList)
            //    {
            //        Console.WriteLine(task.ToString());
            //    } var qualquer = new UserTasks();
            //}
            var query = users.GroupJoin(
                tasks,
                user => Int32.Parse(user.Id),
                task => task.AssignedTo,
                (user, task) => new UserTasks()
                {
                    User = user,
                    TaskList = task
                }
                );

            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void WriteWithSyntaxLINQ(List<User> users, List<Task> tasks)
        {
            Console.WriteLine();
            Console.WriteLine("\n-----------Com recurso a LINQ - Query Syntax-----------");
            Console.WriteLine();

            //List<User> userListQ = (from user in users select user).ToList();

            //foreach (var user in userListQ)
            //{
            //    Console.WriteLine(user.ToString());
            //    List<Task> taskList = (from task in tasks where task.AssignedTo == Int32.Parse(user.Id) select task).ToList();
            //    foreach (var task in taskList)
            //    {
            //        Console.WriteLine(task.ToString());
            //    }
            //}
            var query = from task in tasks
                        group task by task.AssignedTo into usertask
                        join user in users on usertask.FirstOrDefault().AssignedTo equals Int32.Parse(user.Id)
                        select new UserTasks()
                        {
                            User = user,
                            TaskList = usertask
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private static void WriteWithoutLINQ(List<User> users, List<Task> tasks)
        {
            Console.WriteLine("-----------Sem recurso a LINQ-----------");
            Console.WriteLine();
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
                var userId = Int32.Parse(user.Id);
                foreach (var task in tasks)
                {
                    if (userId == task.AssignedTo)
                    {
                        Console.WriteLine(task.ToString());
                    }
                }
            }
        }
    }
}