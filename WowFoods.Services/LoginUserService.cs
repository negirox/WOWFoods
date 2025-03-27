using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowFoods.Models;
using WowFoodsApp.Repository;
using WowFoodsViewModels.Models;

namespace WowFoods.Services
{
    public class LoginUserService(ILoginRepository loginRepository) : ILoginUserService
    {
        private readonly ILoginRepository _loginRepository = loginRepository;

        public async Task<bool> LoginCheck(UserLoginViewModel userLoginViewModel)
        {
            User user = new()
            {
                Username = userLoginViewModel.Username,
                Password = userLoginViewModel.Password
            };
            var isLogin = await _loginRepository.LoginCheck(user);
            return isLogin;
        }
    }
}
