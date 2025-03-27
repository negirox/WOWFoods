using System.Threading.Tasks;
using WowFoodsApp.Repository;

namespace WowFoods.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;

        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<decimal> GetTotalSalesAsync()
        {
            // Simulate async operation
            return await Task.FromResult(_salesRepository.GetTotalSales());
        }

        public async Task<decimal> GetTotalProfitAsync()
        {
            // Simulate async operation
            return await Task.FromResult(_salesRepository.GetTotalProfit());
        }
    }
}
