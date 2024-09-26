using BlazorGourmet.Client.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorGourmet.Client.Services;

public class CachedMemberService(IMealDbService mealDbService, IMemoryCache memoryCache) : IMealDbService
{
    private readonly IMealDbService _mealDbService = mealDbService;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);

    public async Task<List<Category>?> GetCategories()
    {
        return await _memoryCache.GetOrCreateAsync("categories", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheExpiration;
            return _mealDbService.GetCategories();
        });
    }

    public List<Country> GetCountriesPaged(int pageNumber, int pageSize = 6)
    {
        return _mealDbService.GetCountriesPaged(pageNumber, pageSize);
    }

    public async Task<List<Recipe>> GetLastestRecipes()
    {
        return await _memoryCache.GetOrCreateAsync("latestRecipes", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheExpiration;
            return _mealDbService.GetLastestRecipes();
        });
    }


    public async Task<Recipe?> GetMealById(string id)
    {
        return await _memoryCache.GetOrCreateAsync($"meal-{id}", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheExpiration;
            return _mealDbService.GetMealById(id);
        });
    }

    public async Task<List<Recipe>?> GetMealsByArea(string area)
    {
        return await _memoryCache.GetOrCreateAsync($"meals-{area}", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheExpiration;
            return _mealDbService.GetMealsByArea(area);
        });
    }
}
