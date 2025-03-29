namespace Store.Repository.Repository
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


        public const string SelectAllProducts = "SELECT * FROM tbl_products";
        public const string InsertProduct = "INSERT INTO tbl_products (name, category, description, rate, qty, added_date, added_by) VALUES (@name, @category, @description, @rate, @qty, @added_date, @added_by)";
        public const string UpdateProduct = "UPDATE tbl_products SET name=@name, category=@category, description=@description, rate=@rate, qty=@qty, added_date=@added_date, added_by=@added_by WHERE id=@id";
        public const string DeleteProduct = "DELETE FROM tbl_products WHERE id=@id";
        public const string SearchProducts = "SELECT * FROM tbl_products WHERE id LIKE @keywords OR name LIKE @keywords OR category LIKE @keywords";
        public const string GetProductsForTransaction = "SELECT name, rate, qty FROM tbl_products WHERE id LIKE @keywords OR name LIKE @keywords";
        public const string GetProductIDFromName = "SELECT id FROM tbl_products WHERE name=@name";
        public const string GetProductQty = "SELECT qty FROM tbl_products WHERE id=@id";
        public const string UpdateQuantity = "UPDATE tbl_products SET qty=@qty WHERE id=@id";
        public const string DisplayProductsByCategory = "SELECT * FROM tbl_products WHERE category=@category";

        public const string InsertTransaction = "INSERT INTO tbl_transactions (type, dea_cust_id, grandTotal, transaction_date, tax, discount, added_by) VALUES (@type, @dea_cust_id, @grandTotal, @transaction_date, @tax, @discount, @added_by); SELECT @@IDENTITY;";
        public const string SelectAllTransactions = "SELECT * FROM tbl_transactions";
        public const string SelectTransactionsByType = "SELECT * FROM tbl_transactions WHERE type=@type";

        public const string InsertTransactionDetail = "INSERT INTO tbl_transaction_detail (product_id, rate, qty, total, dea_cust_id, added_date, added_by) VALUES (@product_id, @rate, @qty, @total, @dea_cust_id, @added_date, @added_by)";


        //public const string SelectAllUsers = @"SELECT id,
        //first_name as FirstName, last_name as LastName, email as EmailId, username as UserName, password as Password, contact as ContactNo, address as Address, 
        //gender as Gender, user_type as UserType, added_date as Created,
        //userImage as UserImage, userSalary , aadharNo FROM tbl_Users";

        public const string SelectAllUsers = @"SELECT id,
        first_name as FirstName, last_name, email, username, password, contact, address, 
        gender, user_type, added_date,
        userImage, userSalary , aadharNo FROM tbl_Users";

        public const string InsertUser = @"
        INSERT INTO tbl_Users (first_name, last_name, email, username, password, contact, address, gender, user_type, added_date, added_by, userImage, userSalary, aadharNo)
        VALUES (@first_name, @last_name, @email, @username, @password, @contact, @address, @gender, @user_type, @added_date, @added_by, @userImage, @userSalary, @aadharNo)";
        public const string UpdateUser = @"
        UPDATE tbl_Users
        SET first_name = @first_name, last_name = @last_name, email = @email, username = @username, password = @password, contact = @contact, address = @address, gender = @gender, user_type = @user_type, added_date = @added_date, added_by = @added_by, userImage = @userImage, userSalary = @userSalary, aadharNo = @aadharNo
        WHERE id = @id";
        public const string DeleteUser = "DELETE FROM tbl_Users WHERE id = @id";
        public const string SearchUsers = "SELECT * FROM tbl_Users WHERE first_name LIKE @keywords OR last_name LIKE @keywords OR email LIKE @keywords OR username LIKE @keywords";
        public const string GetUserIDFromUsername = "SELECT id FROM tbl_Users WHERE username = @username";
        public const string UpdateUserSalary = "UPDATE tbl_Users SET userSalary = @newSalary WHERE id = @userId";
        public const string SearchSingleUser = "SELECT * FROM tbl_Users WHERE id=@id";


        public const string GetStaffTransactionDetail = "SELECT * FROM StaffTransactions WHERE UserId = @UserId";
        public const string InsertStaffTransactions = "INSERT INTO StaffTransactions (UserId, Amount, Reason, TransactionDate, TransactionType) VALUES (@UserId, @Amount, @Reason, @TransactionDate, @TransactionType)";

        public const string GetTransactionSummary = @"SELECT 
            CAST(transaction_date AS DATE) AS Date,
            SUM(grandTotal) AS TotalAmount,
            SUM(tax) AS TotalTax,
            SUM(discount) AS TotalDiscount
        FROM 
            [WowFoods].[dbo].[tbl_transactions]
        WHERE 
            transaction_date BETWEEN @startDate AND @endDate
        GROUP BY 
            CAST(transaction_date AS DATE)
        ORDER BY 
            Date;";
    }
}
