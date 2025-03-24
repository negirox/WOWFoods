using System.Data;
using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface IProductsDAL
    {
        bool DecreaseProduct(int ProductID, decimal Qty);
        bool Delete(ProductsBLL p);
        DataTable DisplayProductsByCategory(string category);
        ProductsBLL GetProductIDFromName(string ProductName);
        decimal GetProductQty(int ProductID);
        ProductsBLL GetProductsForTransaction(string keyword);
        bool IncreaseProduct(int ProductID, decimal IncreaseQty);
        bool Insert(ProductsBLL p);
        DataTable Search(string keywords);
        DataTable Select();
        bool Update(ProductsBLL p);
        bool UpdateQuantity(int ProductID, decimal Qty);
    }
}