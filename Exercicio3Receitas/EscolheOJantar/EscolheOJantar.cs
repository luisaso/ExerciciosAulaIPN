namespace Exercicio3Receitas
{
    public class EscolheOJantar
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string[] possibleSelections = { "1", "2", "3", "4", "0" };
                string selection;
                do
                {
                    Console.WriteLine("Selecionar receita por:\n" +
                        "1 - Todas (ordenadas alfabeticamente)\n" +
                        "2 - Todas (ordenadas por tempo de preparação)\n" +
                        "3 - Todas (ordenadas por número de pessoas que serve)\n" +
                        "4 - Tag\n" +
                        "0 - Sair\n");
                    selection = Console.ReadLine();
                }
                while (!possibleSelections.Contains(selection));
                if (selection == "0") break;
                List<Receita> recipes = RepoReceitas.LoadRecipes();
                SelectOption(selection, recipes);
            }

        }

        private static void SelectOption(string? selection, List<Receita> recipes)
        {
            List<ReceitaShort> listRecipesOrdered = new();

            ServicoReceitas servicoReceitas = new();

            switch (selection)
            {
                case "1":
                    listRecipesOrdered = servicoReceitas.OrdenarAlfabeticamente(recipes);
                    break;

                case "2":
                    listRecipesOrdered = servicoReceitas.OrdenarPorTempo(recipes);
                    break;

                case "3":
                    listRecipesOrdered = servicoReceitas.OrdenarPorQuantidadeServida(recipes);
                    break;

                case "4":
                    List<string> listRecipes = servicoReceitas.MostrarTags(recipes);
                    string tagSelected = SelectTag(listRecipes);
                    listRecipesOrdered = servicoReceitas.OrdenarPorTag(recipes, tagSelected);
                    break;

                default:
                    break;
            }
            string idSelected = SelectId(listRecipesOrdered, selection);
            Receita receitaEscolhida = servicoReceitas.EscolherReceita(recipes, idSelected);
            servicoReceitas.MostraReceita(receitaEscolhida);
        }
        private static string SelectId(List<ReceitaShort> listRecipes, string selection)
        {
            List<string> permitedIds = new();
            Console.WriteLine();
            foreach (var item in listRecipes)
            {
                int horas = (int)Math.Floor(item.Totaltime / 3600.0);
                int min = (int)((item.Totaltime / 60) % 60.0);

                if (selection == "2")
                {
                    Console.Write($"{item.Id,-3}" + " - " + item.Name.ToString().PadRight(85, '-'));
                    Console.WriteLine("Tempo Total: " + horas + ":" + min.ToString("00") + "H");
                }
                else if (selection == "3")
                {
                    Console.Write($"{item.Id,-3}" + " - " + item.Name.ToString().PadRight(85, '-'));
                    Console.WriteLine("Porções: " + item.Servings.ToString("00"));
                }
                else
                {
                    Console.WriteLine($"{item.Id,-3}" + " - " + item.Name);
                }

                permitedIds.Add(item.Id);
            }

            string idSelected;
            do
            {
                Console.WriteLine("\nEscolher qual o número da receita:\n");
                idSelected = Console.ReadLine();
            }
            while (!permitedIds.Contains(idSelected));
            return idSelected;
        }
        private static string SelectTag(List<string> listReceitas)
        {
            string tagSelected;
            do
            {
                Console.WriteLine("\nEscolher qual a Tag a utilizar:\n");
                tagSelected = Console.ReadLine();
            }
            while (!listReceitas.Contains(tagSelected));
            return tagSelected;
        }
    }
}