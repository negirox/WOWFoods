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
                new SqlParameter("@added_by", u.added_by),
                new SqlParameter("@userImage", u.userImage),
                new SqlParameter("@userSalary", u.userSalary),
                new SqlParameter("@aadharNo", u.aadharNo),
                new SqlParameter("@DefaultSalary", u.userSalary),
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
                new SqlParameter("@userImage", u.userImage),
                new SqlParameter("@userSalary", u.userSalary),
                new SqlParameter("@aadharNo", u.aadharNo),
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

        public UserBLL GetUser(int id)
        {
            UserBLL u = new UserBLL();

            SqlParameter[] parameters = {
                new SqlParameter("@id", id)
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.SearchSingleUser, parameters);
                if (dt.Rows.Count > 0)
                {
                    u.id = int.Parse(Convert.ToString(dt.Rows[0]["id"]));
                    u.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
                    u.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
                    u.email = Convert.ToString(dt.Rows[0]["email"]);
                    u.username = Convert.ToString(dt.Rows[0]["username"]);
                    u.password = Convert.ToString(dt.Rows[0]["password"]);
                    u.contact = Convert.ToString(dt.Rows[0]["contact"]);
                    u.address = Convert.ToString(dt.Rows[0]["address"]);
                    u.gender = Convert.ToString(dt.Rows[0]["gender"]);
                    u.user_type = Convert.ToString(dt.Rows[0]["user_type"]);
                    u.added_date = DateTime.Parse(Convert.ToString(dt.Rows[0]["added_date"]));
                    u.userImage = dt.Rows[0]["userImage"] != DBNull.Value ? (byte[])dt.Rows[0]["userImage"] : null;
                    u.userSalary = Convert.ToString(dt.Rows[0]["userSalary"]);
                    u.aadharNo = Convert.ToString(dt.Rows[0]["aadharNo"]);
                    u.DefaultSalary = Convert.ToString(dt.Rows[0]["DefaultSalary"]);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return u;
        }

        public bool UpdateUserSalary(int userId, decimal newSalary)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@userId", userId),
                new SqlParameter("@newSalary", newSalary)
            };
            bool isSuccess;
            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.UpdateUserSalary, parameters);
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
