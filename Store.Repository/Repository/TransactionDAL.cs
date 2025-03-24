using Store.Models.BLL;
using Store.Repository.Logging;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Store.Repository.Repository
{
    public class TransactionDAL : ITransactionDAL
    {
        #region Insert Transaction Method
        public bool Insert_Transaction(TransactionsBLL t, out int transactionID)
        {
            bool isSuccess = false;
            transactionID = -1;

            SqlParameter[] parameters = {
                new SqlParameter("@type", t.type),
                new SqlParameter("@dea_cust_id", t.dea_cust_id),
                new SqlParameter("@grandTotal", t.grandTotal),
                new SqlParameter("@transaction_date", t.transaction_date),
                new SqlParameter("@tax", t.tax),
                new SqlParameter("@discount", t.discount),
                new SqlParameter("@added_by", t.added_by)
            };

            try
            {
                object o = SqlHelper.ExecuteScalar(SqlQueries.InsertTransaction, parameters);
                if (o != null)
                {
                    transactionID = int.Parse(o.ToString());
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return isSuccess;
        }
        #endregion

        #region METHOD TO DISPLAY ALL THE TRANSACTION
        public DataTable DisplayAllTransactions()
        {
            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SelectAllTransactions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region METHOD TO DISPLAY TRANSACTION BASED ON TRANSACTION TYPE
        public DataTable DisplayTransactionByType(string type)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@type", type)
            };

            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SelectTransactionsByType, parameters);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion
    }
}
