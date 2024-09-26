using BlazorGourmet.Client.Models;

namespace BlazorGourmet.Client.Services;

public class MealDbService(IHttpClientFactory httpClientFactory) : IMealDbService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("MealDbClient");

    public async Task<List<Category>?> GetCategories()
    {
        var response = await _httpClient.GetFromJsonAsync<CategoryResponse>("categories.php");

        return response?.Categories;
    }

    public List<Country> GetCountriesPaged(int pageNumber, int pageSize = 6)
    {
        return GetCountries().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    private static List<Country> GetCountries()
    {
        return [
            new Country { Area = "American", Flag = "/images/us.png" },
            new Country { Area = "British", Flag = "/images/gb.png" },
            new Country { Area = "Canadian", Flag = "/images/ca.png" },
            new Country { Area = "Chinese", Flag = "/images/cn.png" },
            new Country { Area = "Croatian", Flag = "/images/hr.png" },
            new Country { Area = "Egyptian", Flag = "/images/eg.png" },
            new Country { Area = "French", Flag = "/images/fr.png" },
            new Country { Area = "Greek", Flag = "/images/gr.png" },
            new Country { Area = "Indian", Flag = "/images/in.png" },
            new Country { Area = "Irish", Flag = "/images/ie.png" },
            new Country { Area = "Italian", Flag = "/images/it.png" },
            new Country { Area = "Jamaican", Flag = "/images/jm.png" },
            new Country { Area = "Japanese", Flag = "/images/jp.png" },
            new Country { Area = "Kenyan", Flag = "/images/kn.png" },
            new Country { Area = "Malaysian", Flag = "/images/my.png" },
            new Country { Area = "Mexican", Flag = "/images/mx.png" },
            new Country { Area = "Moroccan", Flag = "/images/ma.png" },
            new Country { Area = "Polish", Flag = "/images/pl.png" },
            new Country { Area = "Portuguese", Flag = "/images/pt.png" },
            new Country { Area = "Russian", Flag = "/images/ru.png" },
            new Country { Area = "Spanish", Flag = "/images/es.png" },
            new Country { Area = "Thai", Flag = "/images/th.png" },
            new Country { Area = "Tunisian", Flag = "/images/tn.png" },
            new Country { Area = "Turkish", Flag = "/images/tr.png" },
            new Country { Area = "Ukrainian", Flag = "/images/UA.png" },
            new Country { Area = "Vietnamese", Flag = "/images/vn.png" }
        ];
    }


    public async Task<List<Recipe>> GetLastestRecipes()
    {
        List<Recipe> recipes = [];
        for (int i = 0; i < 3; i++)
        {
            var response = await _httpClient.GetFromJsonAsync<RecipeResponse>("random.php");
            if (response != null)
                recipes.AddRange(response.Recipes.Where(r => r != null).Select(r => r));
        }

        return recipes;
    }

    public async Task<Recipe?> GetMealById(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<RecipeResponse>($"lookup.php?i={id}");

        return response!.Recipes.FirstOrDefault();
    }

    public async Task<List<Recipe>?> GetMealsByArea(string area)
    {
        var response = await _httpClient.GetFromJsonAsync<RecipeResponse>($"filter.php?a={area}");

        return response?.Recipes?.Take(8).ToList() ?? [];
    }
}
