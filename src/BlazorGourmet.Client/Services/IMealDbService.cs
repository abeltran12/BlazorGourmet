using BlazorGourmet.Client.Models;

namespace BlazorGourmet.Client.Services;

public interface IMealDbService
{
    Task<List<Category>?> GetCategories();

    Task<List<Recipe>> GetLastestRecipes();

    Task<Recipe?> GetMealById(string id);

    List<Country> GetCountriesPaged(int pageNumber, int pageSize = 6);

    Task<List<Recipe>?> GetMealsByArea(string area);
}
