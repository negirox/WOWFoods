using System.Data;
using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface IDeaCustDAL
    {
        bool Delete(DeaCustBLL dc);
        DeaCustBLL GetDeaCustIDFromName(string name);
        bool Insert(DeaCustBLL dc);
        DataTable Search(string keyword);
        DeaCustBLL SearchDealerCustomerForTransaction(string keyword);
        DataTable Select();
        bool Update(DeaCustBLL dc);
    }
}