using Microsoft.EntityFrameworkCore;
using WowFoods.Models;

namespace WowFoodsApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    AddedBy = p.AddedBy,
                    Category = new Category() { Name = p.Category.Name, CategoryId = p.CategoryId } // Include CategoryName
                }).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product? productRecord = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.ProductId == id)
                .Select(p => new Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    AddedBy = p.AddedBy,
                    Category = new Category() { Name = p.Category.Name, CategoryId = p.CategoryId } // Include CategoryName
                }).FirstOrDefaultAsync();
            return productRecord;
        }

        public async Task AddProductAsync(Product product)
        {
            var entity = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                AddedBy = product.AddedBy
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var entity = await _context.Products.FindAsync(product.ProductId);
            if (entity != null)
            {
                entity.Name = product.Name;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}




