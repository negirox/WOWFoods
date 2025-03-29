using System.Data;

public interface IStaffTransactionDAL
{
    DataTable GetTransactionsByUserId(int userId);
    bool InsertTransaction(StaffTransactionBLL transaction);
}