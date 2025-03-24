using System;
using System.Data;
using System.Data.SqlClient;
using Store.Models.BLL;
using Store.Repository.Logging;

namespace Store.Repository.Repository
{
    public class UserDAL : IUserDAL
    {
        #region Select Data from Database
        public DataTable Select()
        {
            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SelectAllUsers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region Insert Data in Database
        public bool Insert(UserBLL u)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@first_name", u.first_name),
                new SqlParameter("@last_name", u.last_name),
                new SqlParameter("@email", u.email),
                new SqlParameter("@username", u.username),
                new SqlParameter("@password", u.password),
                new SqlParameter("@contact", u.contact),
                new SqlParameter("@address", u.address),
                new SqlParameter("@gender", u.gender),
                new SqlParameter("@user_type", u.user_type),
                new SqlParameter("@added_date", u.added_date),
                new SqlParameter("@added_by", u.added_by)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.InsertUser, parameters);
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

        #region Update data in Database
        public bool Update(UserBLL u)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@first_name", u.first_name),
                new SqlParameter("@last_name", u.last_name),
                new SqlParameter("@email", u.email),
                new SqlParameter("@username", u.username),
                new SqlParameter("@password", u.password),
                new SqlParameter("@contact", u.contact),
                new SqlParameter("@address", u.address),
                new SqlParameter("@gender", u.gender),
                new SqlParameter("@user_type", u.user_type),
                new SqlParameter("@added_date", u.added_date),
                new SqlParameter("@added_by", u.added_by),
                new SqlParameter("@id", u.id)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.UpdateUser, parameters);
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

        #region Delete Data from Database
        public bool Delete(UserBLL u)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@id", u.id)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.DeleteUser, parameters);
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

        #region Search User on Database using Keywords
        public DataTable Search(string keywords)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@keywords", "%" + keywords + "%")
            };

            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SearchUsers, parameters);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region Getting User ID from Username
        public UserBLL GetIDFromUsername(string username)
        {
            UserBLL u = new UserBLL();

            SqlParameter[] parameters = {
                new SqlParameter("@username", username)
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.GetUserIDFromUsername, parameters);

                if (dt.Rows.Count > 0)
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return u;
        }
        #endregion
    }
}
