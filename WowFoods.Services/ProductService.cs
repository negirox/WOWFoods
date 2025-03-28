using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WowFoods.Models;
using WowFoodsApp.Repository;
using WowFoodsViewModels.Models;

namespace WowFoodsApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                AddedBy = p.AddedBy
            }).ToList();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                AddedBy = product.AddedBy
            };
        }

        public async Task AddProductAsync(ProductViewModel product)
        {
            ValidateModel(product);
            var entity = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                AddedBy = product.AddedBy ?? 1 // replace with logged in user ID
            };
            await _productRepository.AddProductAsync(entity);
        }

        public async Task UpdateProductAsync(ProductViewModel product)
        {
            ValidateModel(product);
            var entity = new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                AddedBy = product.AddedBy
            };
            await _productRepository.UpdateProductAsync(entity);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        private void ValidateModel(ProductViewModel product)
        {
            var validationContext = new ValidationContext(product);
            Validator.ValidateObject(product, validationContext, validateAllProperties: true);
        }
    }
}

