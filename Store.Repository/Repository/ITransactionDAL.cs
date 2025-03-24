using System.Data;
using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface ITransactionDAL
    {
        DataTable DisplayAllTransactions();
        DataTable DisplayTransactionByType(string type);
        bool Insert_Transaction(TransactionsBLL transactionsBLL, out int transactionID);
    }
}