using RedisSample.Models;

namespace RedisSample.Services
{
    public class CategoryService : ICategoryService
    {
        static List<CategoryModel> categories => new()
        {
            new CategoryModel { Id = 1, Name = "Electronic" },
            new CategoryModel { Id = 2, Name = "Clothes" },
            new CategoryModel { Id = 3, Name = "Vehicles" },
            new CategoryModel { Id = 4, Name = "Sports" }
        };

        public ICacheService _cacheService { get; }

        public CategoryService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public List<CategoryModel> GetAllCategory()
        {
            return GetCategoriesFromCache();
        }

        private List<CategoryModel> GetCategoriesFromCache()
        {
            return _cacheService.GetOrAdd("categories", () => { return categories; });
        }
    }
}
