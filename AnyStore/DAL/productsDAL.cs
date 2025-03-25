using System;
using System.Data;
using System.Data.SqlClient;
using Store.Models.BLL;
using Store.Repository.Logging;

namespace Store.Repository.Repository
{
    public class productsDAL
    {
        #region Select method for Product Module
        public DataTable Select()
        {
            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SelectAllProducts);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region Method to Insert Product in database
        public bool Insert(ProductsBLL p)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@name", p.name),
                new SqlParameter("@category", p.category),
                new SqlParameter("@description", p.description),
                new SqlParameter("@rate", p.rate),
                new SqlParameter("@qty", p.qty),
                new SqlParameter("@added_date", p.added_date),
                new SqlParameter("@added_by", p.added_by)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.InsertProduct, parameters);
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

        #region Method to Update Product in Database
        public bool Update(ProductsBLL p)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@name", p.name),
                new SqlParameter("@category", p.category),
                new SqlParameter("@description", p.description),
                new SqlParameter("@rate", p.rate),
                new SqlParameter("@qty", p.qty),
                new SqlParameter("@added_date", p.added_date),
                new SqlParameter("@added_by", p.added_by),
                new SqlParameter("@id", p.id)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.UpdateProduct, parameters);
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

        #region Method to Delete Product from Database
        public bool Delete(ProductsBLL p)
        {
            bool isSuccess = false;

            SqlParameter[] parameters = {
                new SqlParameter("@id", p.id)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.DeleteProduct, parameters);
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

        #region SEARCH Method for Product Module
        public DataTable Search(string keywords)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@keywords", "%" + keywords + "%")
            };

            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.SearchProducts, parameters);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region METHOD TO SEARCH PRODUCT IN TRANSACTION MODULE
        public ProductsBLL GetProductsForTransaction(string keyword)
        {
            ProductsBLL p = new ProductsBLL();

            SqlParameter[] parameters = {
                new SqlParameter("@keywords", "%" + keyword + "%")
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.GetProductsForTransaction, parameters);

                if (dt.Rows.Count > 0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return p;
        }
        #endregion

        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public ProductsBLL GetProductIDFromName(string ProductName)
        {
            ProductsBLL p = new ProductsBLL();

            SqlParameter[] parameters = {
                new SqlParameter("@name", ProductName)
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.GetProductIDFromName, parameters);

                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return p;
        }
        #endregion

        #region METHOD TO GET CURRENT Quantity from the Database based on Product ID
        public decimal GetProductQty(int ProductID)
        {
            decimal qty = 0;

            SqlParameter[] parameters = {
                new SqlParameter("@id", ProductID)
            };

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.GetProductQty, parameters);

                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return qty;
        }
        #endregion

        #region METHOD TO UPDATE QUANTITY
        public bool UpdateQuantity(int ProductID, decimal Qty)
        {
            bool success = false;

            SqlParameter[] parameters = {
                new SqlParameter("@qty", Qty),
                new SqlParameter("@id", ProductID)
            };

            try
            {
                int rows = SqlHelper.ExecuteNonQuery(SqlQueries.UpdateQuantity, parameters);
                success = rows > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return success;
        }
        #endregion

        #region METHOD TO INCREASE PRODUCT
        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {
            bool success = false;

            try
            {
                decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty + IncreaseQty;
                success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return success;
        }
        #endregion

        #region METHOD TO DECREASE PRODUCT
        public bool DecreaseProduct(int ProductID, decimal Qty)
        {
            bool success = false;

            try
            {
                decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty - Qty;
                success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }

            return success;
        }
        #endregion

        #region DISPLAY PRODUCTS BASED ON CATEGORIES
        public DataTable DisplayProductsByCategory(string category)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@category", category)
            };

            try
            {
                return SqlHelper.ExecuteQuery(SqlQueries.DisplayProductsByCategory, parameters);
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
