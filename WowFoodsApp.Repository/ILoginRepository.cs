
using WowFoods.Models;

namespace WowFoodsApp.Repository
{
    public interface ILoginRepository

    {
        Task<bool> LoginCheck(User login);
    }
}