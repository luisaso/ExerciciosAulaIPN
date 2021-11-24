using Newtonsoft.Json;

namespace Exercicio1Aulas
{
    public class Utilizador
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Utilizador(string firstName, string lastName, int age, double height, double weight)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            Weight = weight;

        }

        public double CalcularIMC() => Weight / (Height * Height);

        public int DevolverAnoDeNascimento() => DateTime.Now.Year - Age;

        public override string ToString()
        {
            string output = $"O {FirstName} {LastName} nasceu em {DevolverAnoDeNascimento()} e tem um IMC de {CalcularIMC()}.";
            return output;
        }

        public static List<Utilizador> ReadJSON()
        {
            string fileName = @"C:\Users\lcspa\Desktop\IT_Academy\Projetos_VS\Exercicio1_Aulas\users.json";
            string jsonString = File.ReadAllText(fileName);

            var user = JsonConvert.DeserializeObject<List<Utilizador>>(jsonString);
            return user;
        }
    }
}
