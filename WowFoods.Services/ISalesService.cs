using System.Threading.Tasks;

namespace WowFoods.Services
{
    public interface ISalesService
    {
        Task<decimal> GetTotalSalesAsync();
        Task<decimal> GetTotalProfitAsync();
    }
}
