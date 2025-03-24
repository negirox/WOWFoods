using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface ITransactionDetailDAL
    {
        bool InsertTransactionDetail(TransactionDetailBLL td);
    }
}