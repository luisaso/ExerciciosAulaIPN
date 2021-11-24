

namespace MyNamespace
{
    public partial class MyProgram
    {
        public static void Main(string[] args)
        {
            List<User> users = User.ReadJSON();
            List<Task> tasks = Task.ReadJSON();

            Console.WriteLine("Sem recurso a LINQ");
            Console.WriteLine();
            ////Sem LINQ
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
            Console.WriteLine();
            Console.WriteLine("Com recurso a LINQ - Query Syntax");
            Console.WriteLine();
            ////Com LINQ - Query Syntax
            List<User> userListQ = (from user in users select user).ToList();

            foreach (var user in userListQ)
            {
                Console.WriteLine(user.ToString());
                List<Task> taskList = (from task in tasks where task.AssignedTo == Int32.Parse(user.Id) select task).ToList();
                foreach (var task in taskList)
                {
                    Console.WriteLine(task.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Com recurso a LINQ - Query Syntax");
            Console.WriteLine();
            //Com LINQ - Method Syntax
            List<User> userListM = users.Select(user => user).ToList();

            foreach (var user in userListM)
            {
                Console.WriteLine(user.ToString());
                List<Task> taskList = tasks.Where(task => task.AssignedTo.Equals(Int32.Parse(user.Id))).ToList();
                foreach (var task in taskList)
                {
                    Console.WriteLine(task.ToString());
                }
            }

        }
    }
}