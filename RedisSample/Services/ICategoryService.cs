using RedisSample.Models;

namespace RedisSample.Services
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAllCategory();
    }
}