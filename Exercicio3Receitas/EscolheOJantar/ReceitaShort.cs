namespace Exercicio3Receitas
{
    public class ReceitaShort
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Totaltime { get; set; }
        public int Servings { get; set; }

        public ReceitaShort(string id, string name, int total, int servings)
        {
            Id = id;
            Name = name;
            Totaltime = total;
            Servings = servings;
        }
    }
}
