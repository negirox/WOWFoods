using WowFoodsApp.Repository;

public class SalesRepository(AppDbContext context) : ISalesRepository
{
    private readonly AppDbContext _context = context;

    public decimal GetTotalSales()
    {
        // return _context.Sales.Sum(s => s.Amount);
        decimal M200 = 200.43M;
        return M200;
    }

    public decimal GetTotalProfit()
    {
        // return _context.Sales.Sum(s => s.Profit);
        decimal M200 = 200.43M;
        return M200;
    }
}
