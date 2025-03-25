using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Store.Repository.Repository;

namespace AnyStore.UI
{
    public partial class frmChart : Form
    {
        IReportRepository reportRepository = new ReportRepository();
        public frmChart()
        {
            InitializeComponent();
        }

        private void cmbIntervalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string intervalType = cmbIntervalType.Text;
            bool isCustom = false;
            fromDate.Enabled = isCustom;
            fromDate.Visible = isCustom;
            toDate.Enabled = isCustom;
            toDate.Visible = isCustom;
            DataTable dt;
            switch (intervalType) { 
               case "Daily":
                    // Display daily sales chart
                    dt = reportRepository.GetTransactionSummaryByQuery(intervalType, DateTime.Now.AddDays(-1), DateTime.Now);
                    BindDataToChart(dt,intervalType);
                    break;
                case "Weekly":
                    // Display weekly sales chart
                    dt = reportRepository.GetTransactionSummary(intervalType, DateTime.Now.AddDays(-7), DateTime.Now);
                    BindDataToChart(dt, intervalType);
                    break;
                case "Monthly":
                    dt = reportRepository.GetTransactionSummary(intervalType, DateTime.Now.AddMonths(-1), DateTime.Now);
                    BindDataToChart(dt, intervalType);
                    break;
                case "Yearly":
                    dt = reportRepository.GetTransactionSummary(intervalType, DateTime.Now.AddYears(-1), DateTime.Now);
                    BindDataToChart(dt, intervalType);
                    break;
                case "Custom":
                    // Display custom sales chart
                    isCustom = true;
                    fromDate.Enabled = isCustom;
                    fromDate.Visible = isCustom;
                    toDate.Enabled = isCustom;
                    toDate.Visible = isCustom;
                    break;
            }
        }

        private void BindDataToChart(DataTable dt, string intervalType)
        {
            // Clear existing series
            chartTransaction.Series.Clear();

            // Create a new series and set its properties
            Series series = new Series
            {
                Name = "Transaction Summary",
                ChartType = SeriesChartType.Bar // You can change the chart type as needed
            };

            // Add data points to the series
            foreach (DataRow row in dt.Rows)
            {
                string xValue = string.Empty;
                switch (intervalType)
                {
                    case "Daily":
                        xValue = Convert.ToDateTime(row["Date"]).ToString("yyyy-MM-dd");
                        break;
                    case "Monthly":
                        xValue = $"{row["Year"]}-{row["Month"]}";
                        break;
                    case "Yearly":
                        xValue = row["Year"].ToString();
                        break;
                    case "Weekly":
                        xValue = $"{row["Year"]}-W{row["WeekNumber"]}";
                        break;
                }

                series.Points.AddXY(xValue, Convert.ToDecimal(row["TotalAmount"]));
            }

            // Bind the data to the chart
            chartTransaction.Series.Add(series);
            chartTransaction.DataBind();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
