using Microsoft.AspNetCore.Mvc;

namespace WowFoodsApp.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult DashBoardView()
        {
            return View();
        }
    }
}
