using System;

public class StaffTransactionBLL
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionType { get; set; }
}
