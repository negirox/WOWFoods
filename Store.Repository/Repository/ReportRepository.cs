using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
    public class ReportRepository : IReportRepository
    {
        public DataTable GetTransactionSummary(string intervalType, DateTime startDate, DateTime endDate)
        {
            DataTable dt = SqlHelper.ExecuteProcedureQuery("GetTransactionSummary", new SqlParameter[]
            {
                new SqlParameter("@intervalType", intervalType),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            });
            return dt;
        }

        public DataTable GetTransactionSummaryByQuery(string intervalType, DateTime startDate, DateTime endDate)
        {
            DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.GetTransactionSummary, new SqlParameter[]
            {
                new SqlParameter("@intervalType", intervalType),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            });
            return dt;
        }
    }
}
