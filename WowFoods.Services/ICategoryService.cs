using System.Collections.Generic;
using System.Threading.Tasks;
using WowFoodsViewModels.Models;

namespace WowFoodsApp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryViewModel category);
        Task UpdateCategoryAsync(CategoryViewModel category);
        Task DeleteCategoryAsync(int id);
    }
}

