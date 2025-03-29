using Store.Repository.Logging;
using Store.Repository.Repository;
using System.Data.SqlClient;
using System.Data;
using System;

public class StaffTransactionDAL : IStaffTransactionDAL
{
    public bool InsertTransaction(StaffTransactionBLL transaction)
    {
        bool isSuccess = false;

        SqlParameter[] parameters = {
            new SqlParameter("@UserId", transaction.UserId),
            new SqlParameter("@Amount", transaction.Amount),
            new SqlParameter("@Reason", transaction.Reason),
            new SqlParameter("@TransactionDate", transaction.TransactionDate),
            new SqlParameter("@TransactionType", transaction.TransactionType)
        };
        try
        {
            int rows = SqlHelper.ExecuteNonQuery(SqlQueries.InsertStaffTransactions, parameters);
            isSuccess = rows > 0;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            throw;
        }

        return isSuccess;
    }

    public DataTable GetTransactionsByUserId(int userId)
    {
        SqlParameter[] parameters = {
            new SqlParameter("@UserId", userId)
        };
        try
        {
            return SqlHelper.ExecuteQuery(SqlQueries.GetStaffTransactionDetail, parameters);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            throw;
        }
    }
}
