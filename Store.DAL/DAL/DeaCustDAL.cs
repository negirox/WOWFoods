using AnyStore.BLL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AnyStore.DAL
{
    public class DeaCustDAL
    {
        #region SELECT Method for Dealer and Customer
        public DataTable Select()
        {
            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SelectAllDeaCust);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region INSERT Method to Add details of Dealer or Customer
        public bool Insert(DeaCustBLL dc)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@type", dc.type),
                new SqlParameter("@name", dc.name),
                new SqlParameter("@email", dc.email),
                new SqlParameter("@contact", dc.contact),
                new SqlParameter("@address", dc.address),
                new SqlParameter("@added_date", dc.added_date),
                new SqlParameter("@added_by", dc.added_by)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.InsertDeaCust, parameters);
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

        #region UPDATE Method for Dealer and Customer Module
        public bool Update(DeaCustBLL dc)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@type", dc.type),
                new SqlParameter("@name", dc.name),
                new SqlParameter("@email", dc.email),
                new SqlParameter("@contact", dc.contact),
                new SqlParameter("@address", dc.address),
                new SqlParameter("@added_date", dc.added_date),
                new SqlParameter("@added_by", dc.added_by),
                new SqlParameter("@id", dc.id)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.UpdateDeaCust, parameters);
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

        #region DELETE Method for Dealer and Customer Module
        public bool Delete(DeaCustBLL dc)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@id", dc.id)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.DeleteDeaCust, parameters);
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

        #region SEARCH Method for Dealer and Customer Module
        public DataTable Search(string keyword)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@keywords", "%" + keyword + "%")
            };

            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SearchDeaCust, parameters);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region METHOD TO SEARCH DEALER Or CUSTOMER FOR TRANSACTION MODULE
        public DeaCustBLL SearchDealerCustomerForTransaction(string keyword)
        {
            DeaCustBLL dc = new DeaCustBLL();

            SqlParameter[] parameters = {
                new SqlParameter("@keywords", "%" + keyword + "%")
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.SearchDeaCustForTransaction, parameters);

                if (dt.Rows.Count > 0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return dc;
        }
        #endregion

        #region METHOD TO GET ID OF THE DEALER OR CUSTOMER BASED ON NAME
        public DeaCustBLL GetDeaCustIDFromName(string name)
        {
            DeaCustBLL dc = new DeaCustBLL();

            SqlParameter[] parameters = {
                new SqlParameter("@name", name)
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.GetDeaCustIDFromName, parameters);

                if (dt.Rows.Count > 0)
                {
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return dc;
        }
        #endregion
    }
}
