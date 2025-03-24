namespace AnyStore.DAL
{
    public static class SqlQueries
    {
        public const string SelectAllCategories = "SELECT * FROM tbl_categories";
        public const string InsertCategory = "INSERT INTO tbl_categories (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)";
        public const string UpdateCategory = "UPDATE tbl_categories SET title=@title, description=@description, added_date=@added_date, added_by=@added_by WHERE id=@id";
        public const string DeleteCategory = "DELETE FROM tbl_categories WHERE id=@id";
        public const string SearchCategories = "SELECT * FROM tbl_categories WHERE id LIKE @keywords OR title LIKE @keywords OR description LIKE @keywords";

        public const string SelectAllDeaCust = "SELECT * FROM tbl_dea_cust";
        public const string InsertDeaCust = "INSERT INTO tbl_dea_cust (type, name, email, contact, address, added_date, added_by) VALUES (@type, @name, @email, @contact, @address, @added_date, @added_by)";
        public const string UpdateDeaCust = "UPDATE tbl_dea_cust SET type=@type, name=@name, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by WHERE id=@id";
        public const string DeleteDeaCust = "DELETE FROM tbl_dea_cust WHERE id=@id";
        public const string SearchDeaCust = "SELECT * FROM tbl_dea_cust WHERE id LIKE @keywords OR type LIKE @keywords OR name LIKE @keywords";
        public const string SearchDeaCustForTransaction = "SELECT name, email, contact, address FROM tbl_dea_cust WHERE id LIKE @keywords OR name LIKE @keywords";
        public const string GetDeaCustIDFromName = "SELECT id FROM tbl_dea_cust WHERE name=@name";
        
        public const string LoginCheck = "SELECT COUNT(1) FROM tbl_users WHERE username=@username AND password=@password AND user_type=@user_type";

    }
}
