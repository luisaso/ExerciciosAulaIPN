using Newtonsoft.Json;

namespace Exercicio3Receitas
{
    public class RepoReceitas
    {
        public Receita ListRecipes { get; set; }

        public static List<Receita> LoadRecipes()
        {
            string fileName = "recipes.json";
            string jsonString = File.ReadAllText(fileName);

            var recipes = JsonConvert.DeserializeObject<List<Receita>>(jsonString);
            return recipes;
        }
    }
}
