using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WowFoods.Models;
using WowFoodsApp.Repository;
using WowFoodsViewModels.Models;

namespace WowFoodsApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList();
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task AddCategoryAsync(CategoryViewModel category)
        {
            ValidateModel(category);
            var entity = new Category
            {
                Name = category.Name
            };
            await _categoryRepository.AddCategoryAsync(entity);
        }

        public async Task UpdateCategoryAsync(CategoryViewModel category)
        {
            ValidateModel(category);
            var entity = new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
            await _categoryRepository.UpdateCategoryAsync(entity);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        private void ValidateModel(CategoryViewModel category)
        {
            var validationContext = new ValidationContext(category);
            Validator.ValidateObject(category, validationContext, validateAllProperties: true);
        }
    }
}

