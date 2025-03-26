using Store.Models.BLL;
using Store.Repository.Logging;
using System;
using System.Data.SqlClient;

namespace Store.Repository.Repository
{
    public class LoginDAL : ILoginDAL
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