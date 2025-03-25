using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
    public interface IReportRepository
    {
        DataTable GetTransactionSummary(string intervalType, DateTime startDate, DateTime endDate);

        DataTable GetTransactionSummaryByQuery(string intervalType, DateTime startDate, DateTime endDate);
    }
}
