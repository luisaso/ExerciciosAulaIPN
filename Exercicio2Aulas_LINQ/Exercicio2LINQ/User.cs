using Newtonsoft.Json;
using System.Text;

namespace Exercicio2LINQ
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public static List<User> ReadJSON()
        {
            string fileName = @"users2.json";
            //StringBuilder jsonString = new(File.ReadAllText(fileName));
            string jsonString = File.ReadAllText(fileName);

            var users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return users;
        }
        public override string ToString()
        {
            string output = $"\n{FirstName} {LastName} - {Role}";
            return output;
        }
    }
}