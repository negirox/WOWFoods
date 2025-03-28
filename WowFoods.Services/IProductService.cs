using System.Collections.Generic;
using System.Threading.Tasks;
using WowFoodsViewModels.Models;

namespace WowFoodsApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductViewModel product);
        Task UpdateProductAsync(ProductViewModel product);
        Task DeleteProductAsync(int id);
    }
}

