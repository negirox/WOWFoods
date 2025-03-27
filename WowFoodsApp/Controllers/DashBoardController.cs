using Microsoft.AspNetCore.Mvc;
using WowFoodsViewModels.Models;
using WowFoods.Services;

namespace WowFoodsApp.Controllers
{
    public class DashBoardController(ISalesService salesService) : Controller
    {
        private readonly ISalesService _salesService = salesService;

        public async Task<IActionResult> DashBoardView()
        {
            DashBoardViewModel dashBoardViewModel = new()
            {
                TotalSales = await _salesService.GetTotalSalesAsync(),
                TotalProfit = await _salesService.GetTotalProfitAsync()
            };
            return View(dashBoardViewModel);
        }
    }
}