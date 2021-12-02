using System.Text.Json.Serialization;

namespace Exercicio3Receitas
{
    public class Receita
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("preptime")]
        public int Preptime { get; set; }

        [JsonPropertyName("waittime")]
        public int Waittime { get; set; }

        [JsonPropertyName("cooktime")]
        public int Cooktime { get; set; }

        [JsonPropertyName("servings")]
        public int Servings { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonPropertyName("calories")]
        public int Calories { get; set; }

        [JsonPropertyName("fat")]
        public int Fat { get; set; }

        [JsonPropertyName("satfat")]
        public int Satfat { get; set; }

        [JsonPropertyName("carbs")]
        public int Carbs { get; set; }

        [JsonPropertyName("fiber")]
        public int Fiber { get; set; }

        [JsonPropertyName("sugar")]
        public int Sugar { get; set; }

        [JsonPropertyName("protein")]
        public int Protein { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        [JsonPropertyName("ingredients")]
        public List<string> Ingredients { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
