using Microsoft.AspNetCore.Mvc;
using WowFoodsApp.Models;

namespace WowFoodsApp.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ISalesRepository salesRepository;

        public DashBoardController(ISalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        public IActionResult DashBoardView()
        {
            DashBoardViewModel dashBoardViewModel = new DashBoardViewModel();
            dashBoardViewModel.TotalSales = salesRepository.GetTotalSales();
            dashBoardViewModel.TotalProfit = salesRepository.GetTotalProfit();
            return View(dashBoardViewModel);
        }
    }
}
