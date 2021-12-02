using System.Text;

namespace Exercicio3Receitas
{
    public class ServicoReceitas
    {
        public List<ReceitaShort> OrdenarAlfabeticamente(List<Receita> receitas)
        {
            var queryRecipeOrdered = receitas.Select(r => new ReceitaShort(r.Id, r.Name, 0, 0)).OrderBy(r => r.Name).ToList();
            return queryRecipeOrdered;
        }
        public List<ReceitaShort> OrdenarPorTempo(List<Receita> receitas)
        {
            var queryRecipeOrdered = receitas.Select(r => new ReceitaShort(r.Id, r.Name, (r.Preptime + r.Waittime + r.Cooktime), 0)).OrderBy(r => r.Totaltime).ToList();
            return queryRecipeOrdered;
        }
        public List<ReceitaShort> OrdenarPorQuantidadeServida(List<Receita> receitas)
        {
            var queryRecipeOrdered = receitas.Select(r => new ReceitaShort(r.Id, r.Name, 0, r.Servings)).OrderBy(r => r.Servings).ToList();
            return queryRecipeOrdered;
        }
        public List<string> MostrarTags(List<Receita> receitas)
        {
            var queryListAllTags = receitas.SelectMany(t => t.Tags).Distinct().OrderBy(t => t);

            int i = 0;
            foreach (var item in queryListAllTags)
            {
                i++;
                Console.Write($"{item,-15}");
                if (i % 7 == 0)
                {
                    Console.WriteLine("\n");
                }
            }

            List<string> tagsList = queryListAllTags.ToList();

            return tagsList;
        }
        public List<ReceitaShort> OrdenarPorTag(List<Receita> receitas, string tag)
        {
            var queryRecipeWithTag = receitas.Where(t => t.Tags.Contains(tag)).Select(r => new ReceitaShort(r.Id, r.Name, 0, 0)).OrderBy(t => Int32.Parse(t.Id)).ToList();
            return queryRecipeWithTag;
        }
        public Receita EscolherReceita(List<Receita> receitas, string id)
        {
            var query = receitas.Where(r => r.Id == id);
            return query.FirstOrDefault();
        }
        public void MostraReceita(Receita receita)
        {
            int tempoTotal = (receita.Preptime + receita.Waittime + receita.Cooktime) / 60;
            StringBuilder recipeDetails = new StringBuilder();
            recipeDetails.AppendLine("\n\nReceita selecionada:");
            recipeDetails.AppendLine(receita.Id + $" - " + receita.Name);
            recipeDetails.AppendLine("Retirada de: " + receita.Source);

            recipeDetails.AppendLine("\nTempo:");
            recipeDetails.AppendLine("De Preparação -> " + receita.Preptime / 60 + " min");
            recipeDetails.AppendLine("De Espera -> " + receita.Waittime / 60 + " min");
            recipeDetails.AppendLine("De Cozedura ->" + receita.Cooktime / 60 + " min");
            recipeDetails.AppendLine("Total -> " + tempoTotal + " min");

            recipeDetails.AppendLine("\nValores Nutricionais:");
            recipeDetails.AppendLine("Calorias -> " + receita.Calories);
            recipeDetails.AppendLine("CarboHidratos -> " + receita.Carbs);
            recipeDetails.AppendLine("Fibras -> " + receita.Fiber);
            recipeDetails.AppendLine("Açucar -> " + receita.Sugar);
            recipeDetails.AppendLine("Proteína -> " + receita.Protein);
            recipeDetails.AppendLine("Gordura - > " + receita.Fat + " da qual saturada -> " + receita.Satfat);
            recipeDetails.AppendLine("Porções: " + receita.Servings);

            recipeDetails.AppendLine("\nIngredientes:");
            foreach (var ingredient in receita.Ingredients)
            {
                recipeDetails.AppendLine(ingredient);
            }

            recipeDetails.AppendLine("\nComentários:");
            recipeDetails.AppendLine(receita.Comments);

            recipeDetails.AppendLine("\nInstruções:");
            recipeDetails.AppendLine(receita.Instructions);

            recipeDetails.AppendLine("\nTags:");
            foreach (var tag in receita.Tags)
            {
                recipeDetails.AppendLine(tag);
            }

            Console.WriteLine(recipeDetails.ToString());

        }

    }
}
