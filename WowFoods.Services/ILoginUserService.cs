using WowFoodsViewModels.Models;

namespace WowFoods.Services
{
    public interface ILoginUserService
    {
        Task<bool> LoginCheck(UserLoginViewModel userLoginViewModel);
    }
}
