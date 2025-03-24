using AnyStore.BLL;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyStore.DAL
{
    public class LoginDAL
    {
        public bool LoginCheck(LoginBLL login)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@username", login.username),
                new SqlParameter("@password", login.password),
                new SqlParameter("@user_type", login.user_type)
            };

            bool isSuccess;
            try
            {
                int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlQueries.LoginCheck, parameters));
                isSuccess = count > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return isSuccess;
        }
    }
}