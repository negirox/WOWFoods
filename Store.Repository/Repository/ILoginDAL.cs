using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface ILoginDAL
    {
        bool LoginCheck(LoginBLL login);
    }
}