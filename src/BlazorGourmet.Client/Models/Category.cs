using System.Text.Json.Serialization;

namespace BlazorGourmet.Client.Models;

public class Category
{
    [JsonPropertyName("idCategory")]
    public required string Id { get; set; }

    [JsonPropertyName("strCategory")]
    public required string CategoryName { get; set; }

    [JsonPropertyName("strCategoryThumb")]
    public string Image { get; set; } = string.Empty;

    [JsonPropertyName("strCategoryDescription")]
    public string Description { get; set; } = string.Empty;

    public string DescriptionAbre
    {
        get
        {
            return Description.Length > 190
                ? string.Concat(Description.AsSpan(0, 190), "...")
                : Description;
        }
    }
}
