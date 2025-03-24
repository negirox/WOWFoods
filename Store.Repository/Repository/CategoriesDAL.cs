using System.Data;
using System.Data.SqlClient;
using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public class CategoriesDAL : ICategoriesDAL
    {
        #region Select Method
        public DataTable Select()
        {
            return SqlHelper.ExecuteQuery(SqlQueries.SelectAllCategories);
        }
        #endregion

        #region Insert New Category
        public bool Insert(CategoriesBLL c)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@title", c.title),
                new SqlParameter("@description", c.description),
                new SqlParameter("@added_date", c.added_date),
                new SqlParameter("@added_by", c.added_by)
            };

            int rows = SqlHelper.ExecuteNonQuery(SqlQueries.InsertCategory, parameters);
            isSuccess = rows > 0;

            return isSuccess;
        }
        #endregion

        #region Update Method
        public bool Update(CategoriesBLL c)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@title", c.title),
                new SqlParameter("@description", c.description),
                new SqlParameter("@added_date", c.added_date),
                new SqlParameter("@added_by", c.added_by),
                new SqlParameter("@id", c.id)
            };

            int rows = SqlHelper.ExecuteNonQuery(SqlQueries.UpdateCategory, parameters);
            isSuccess = rows > 0;

            return isSuccess;
        }
        #endregion

        #region Delete Category Method
        public bool Delete(CategoriesBLL c)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@id", c.id)
            };

            int rows = SqlHelper.ExecuteNonQuery(SqlQueries.DeleteCategory, parameters);
            isSuccess = rows > 0;

            return isSuccess;
        }
        #endregion

        #region Method for Search Functionality
        public DataTable Search(string keywords)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@keywords", "%" + keywords + "%")
            };

            return SqlHelper.ExecuteQuery(SqlQueries.SearchCategories, parameters);
        }
        #endregion
    }
}
