using NLayer.Core.Models;

namespace NLayer.Core.Repositories;

public interface ICategoryRepository:IGenericRepository<Category>
{
    public Task<Category> GetSingleCategoryByIdProductsAsync(int categoryId);
}