using System;
using System.Data.SqlClient;
using Store.Models.BLL;
using Store.Repository.Logging;

namespace Store.Repository.Repository
{
    public class TransactionDetailDAL : ITransactionDetailDAL
    {
        #region Insert Method for Transaction Detail
        public bool InsertTransactionDetail(TransactionDetailBLL td)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@product_id", td.product_id),
                new SqlParameter("@rate", td.rate),
                new SqlParameter("@qty", td.qty),
                new SqlParameter("@total", td.total),
                new SqlParameter("@dea_cust_id", td.dea_cust_id),
                new SqlParameter("@added_date", td.added_date),
                new SqlParameter("@added_by", td.added_by)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.InsertTransactionDetail, parameters);
                isSuccess = rows > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return isSuccess;
        }
        #endregion
    }
}
