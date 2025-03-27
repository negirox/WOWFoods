using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowFoods.Models;

namespace WowFoodsApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .Where(c => c.CategoryId == id)
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).FirstOrDefaultAsync();
        }

        public async Task AddCategoryAsync(Category category)
        {
            var entity = new Category
            {
                Name = category.Name
            };
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var entity = await _context.Categories.FindAsync(category.CategoryId);
            if (entity != null)
            {
                entity.Name = category.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
