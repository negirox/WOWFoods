using System.Data;
using Store.Models.BLL;

namespace Store.Repository.Repository
{
    public interface ICategoriesDAL
    {
        bool Delete(CategoriesBLL c);
        bool Insert(CategoriesBLL c);
        DataTable Search(string keywords);
        DataTable Select();
        bool Update(CategoriesBLL c);
    }
}