﻿namespace BlazorGourmet.Client.Models;

using System.Text.Json.Serialization;

public class Recipe
{

    [JsonPropertyName("idMeal")]
    public string IdMeal { get; set; } = string.Empty;

    [JsonPropertyName("strMeal")]
    public string Meal { get; set; } = string.Empty;

    [JsonPropertyName("strDrinkAlternate")]
    public object StrDrinkAlternate { get; set; }

    [JsonPropertyName("strCategory")]
    public string? Category { get; set; }

    [JsonPropertyName("strArea")]
    public string? Area { get; set; }

    [JsonPropertyName("strInstructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("strMealThumb")]
    public string? MealThumb { get; set; }

    [JsonPropertyName("strTags")]
    public string? Tags { get; set; }

    [JsonPropertyName("strYoutube")]
    public string? Youtube { get; set; }

    [JsonPropertyName("strIngredient1")]
    public string? Ingredient1 { get; set; }

    [JsonPropertyName("strIngredient2")]
    public string? Ingredient2 { get; set; }

    [JsonPropertyName("strIngredient3")]
    public string? Ingredient3 { get; set; }

    [JsonPropertyName("strIngredient4")]
    public string? Ingredient4 { get; set; }

    [JsonPropertyName("strIngredient5")]
    public string? Ingredient5 { get; set; }

    [JsonPropertyName("strIngredient6")]
    public string? Ingredient6 { get; set; }

    [JsonPropertyName("strIngredient7")]
    public string? Ingredient7 { get; set; }

    [JsonPropertyName("strIngredient8")]
    public string? Ingredient8 { get; set; }

    [JsonPropertyName("strIngredient9")]
    public string? Ingredient9 { get; set; }

    [JsonPropertyName("strIngredient10")]
    public string? Ingredient10 { get; set; }

    [JsonPropertyName("strIngredient11")]
    public string? Ingredient11 { get; set; }

    [JsonPropertyName("strIngredient12")]
    public string? Ingredient12 { get; set; }

    [JsonPropertyName("strIngredient13")]
    public string? Ingredient13 { get; set; }

    [JsonPropertyName("strIngredient14")]
    public string? Ingredient14 { get; set; }

    [JsonPropertyName("strIngredient15")]
    public string? Ingredient15 { get; set; }

    [JsonPropertyName("strIngredient16")]
    public string? Ingredient16 { get; set; }

    [JsonPropertyName("strIngredient17")]
    public string? Ingredient17 { get; set; }

    [JsonPropertyName("strIngredient18")]
    public string? Ingredient18 { get; set; }

    [JsonPropertyName("strIngredient19")]
    public string? Ingredient19 { get; set; }

    [JsonPropertyName("strIngredient20")]
    public string? Ingredient20 { get; set; }

    [JsonPropertyName("strMeasure1")]
    public string? Measure1 { get; set; }

    [JsonPropertyName("strMeasure2")]
    public string? Measure2 { get; set; }

    [JsonPropertyName("strMeasure3")]
    public string? Measure3 { get; set; }

    [JsonPropertyName("strMeasure4")]
    public string? Measure4 { get; set; }

    [JsonPropertyName("strMeasure5")]
    public string? Measure5 { get; set; }

    [JsonPropertyName("strMeasure6")]
    public string? Measure6 { get; set; }

    [JsonPropertyName("strMeasure7")]
    public string? Measure7 { get; set; }

    [JsonPropertyName("strMeasure8")]
    public string? Measure8 { get; set; }

    [JsonPropertyName("strMeasure9")]
    public string? Measure9 { get; set; }

    [JsonPropertyName("strMeasure10")]
    public string? Measure10 { get; set; }

    [JsonPropertyName("strMeasure11")]
    public string? Measure11 { get; set; }

    [JsonPropertyName("strMeasure12")]
    public string? Measure12 { get; set; }

    [JsonPropertyName("strMeasure13")]
    public string? Measure13 { get; set; }

    [JsonPropertyName("strMeasure14")]
    public string? Measure14 { get; set; }

    [JsonPropertyName("strMeasure15")]
    public string? Measure15 { get; set; }

    [JsonPropertyName("strMeasure16")]
    public string? Measure16 { get; set; }

    [JsonPropertyName("strMeasure17")]
    public string? Measure17 { get; set; }

    [JsonPropertyName("strMeasure18")]
    public string? Measure18 { get; set; }

    [JsonPropertyName("strMeasure19")]
    public string? Measure19 { get; set; }

    [JsonPropertyName("strMeasure20")]
    public string? Measure20 { get; set; }

    [JsonPropertyName("strSource")]
    public string? Source { get; set; }
    [JsonPropertyName("strSostrImageSourceurce")]
    public string? strImageSource { get; set; }
    [JsonPropertyName("strCreativeCommonsConfirmed")]
    public string? strCreativeCommonsConfirmed { get; set; }
    [JsonPropertyName("dateModified")]
    public string? dateModified { get; set; }

    public List<string> TagsEnLista
    {
        get
        {
            return !string.IsNullOrEmpty(Tags) 
                ? Tags.Split(',').Select(tag => tag.Trim()).ToList() : [];
        }
    }

    public List<Ingredient> Ingredients
    {
        get
        {
            List<Ingredient> ingredients = [];
            Ingredient ingredient = new();
            int i = 1;

            while (true)
            {
                var property = GetType().GetProperty("Ingredient" + i);
                if (property != null)
                {
                    var value = (string)property!.GetValue(this)!;
                    var measure = GetType().GetProperty("Measure" + i);
                    var measureValue = (string)measure!.GetValue(this)!;
                    if (!string.IsNullOrEmpty(value))
                    {
                        ingredient.Id = i;
                        ingredient.Name = value;
                        ingredient.Messure = measureValue!;
                        ingredients.Add(ingredient);
                    }

                    ingredient = new();
                }
                else
                {
                    break;
                }
                i++;
            }

            return ingredients;
        }
    }
}
