using System.Data;
using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface IUserDAL
    {
        bool Delete(UserBLL u);
        UserBLL GetIDFromUsername(string username);
        bool Insert(UserBLL u);
        DataTable Search(string keywords);
        DataTable Select();
        bool Update(UserBLL u);
    }
}