using Microsoft.AspNetCore.Mvc;
using WowFoods.Models;
using WowFoodsApp.Models;
using WowFoodsApp.Repository;

namespace WowFoodsApp.Controllers
{
    public class UserLoginController(ILoginRepository loginRepository) : Controller
    {
        private readonly ILoginRepository _loginRepository = loginRepository;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                var isLogin = await _loginRepository.LoginCheck(user);
                if(isLogin)
                    return RedirectToAction("DashBoardView", "DashBoard");
                else
                    ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }
    }
     
}
