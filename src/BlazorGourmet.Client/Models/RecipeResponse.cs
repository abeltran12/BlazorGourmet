using System.Text.Json.Serialization;

namespace BlazorGourmet.Client.Models;

public class RecipeResponse
{
    [JsonPropertyName("meals")]
    public required List<Recipe> Recipes { get; set; }
}
