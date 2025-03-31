using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Store.Models.BLL;
using Store.Repository.Repository;

namespace AnyStore.UI
{
    public partial class DailyTransaction : Form
    {
        private readonly UserDAL userService = new UserDAL();
        private readonly IStaffTransactionDAL transactionService = new StaffTransactionDAL();
        private readonly FormHelper formHelper = new FormHelper();
        private int selectedUserId;

        public DailyTransaction()
        {
            InitializeComponent();
            formHelper.FormateDataGridView(dataGridView1);
            LoadDealerCustomerComboBox();
        }

        private void LoadDealerCustomerComboBox()
        {
            DataTable dt = userService.Select();
            cmbSearch.DataSource = dt;
            cmbSearch.DisplayMember = "UserName";
            cmbSearch.ValueMember = "id";
            cmbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = cmbSearch.Text;
            UserBLL user = userService.GetIDFromUsername(username);
            if (user != null)
            {
                user = GetUserSalary(user);
            }
        }

        private UserBLL GetUserSalary(UserBLL user)
        {
            user = userService.GetUser(user.id);
            selectedUserId = user.id;
            lblEmpSalary.Text = (user.DefaultSalary ?? user.userSalary ?? "0").ToString(CultureInfo.InvariantCulture);
            lblRemainingSalary.Text = (user.userSalary ?? "0").ToString(CultureInfo.InvariantCulture); // Initialize remaining salary
            LoadTransactions();
            if (dataGridView1.Rows.Count > 1)
            {
                var remainingAmount = CalculateRemainingSalary();
                lblRemainingSalary.Text = remainingAmount.ToString(CultureInfo.InvariantCulture);
            }

            return user;
        }

        private void LoadTransactions()
        {
            DataTable dt = transactionService.GetTransactionsByUserId(selectedUserId);

            // Create a new DataTable with custom column names
            DataTable customDt = new DataTable();
            customDt.Columns.Add("Transaction ID", typeof(int));
            //customDt.Columns.Add("User ID", typeof(int));
            customDt.Columns.Add("Amount", typeof(decimal));
            customDt.Columns.Add("Reason", typeof(string));
            customDt.Columns.Add("Transaction Date", typeof(DateTime));
            customDt.Columns.Add("Transaction Type", typeof(string));

            // Populate the custom DataTable with data
            foreach (DataRow row in dt.Rows)
            {
                customDt.Rows.Add(
                    row["Id"],
                    //row["UserId"],
                    row["Amount"],
                    row["Reason"],
                    row["TransactionDate"],
                    row["TransactionType"]
                );
            }

            dataGridView1.DataSource = customDt;

            // Format the Amount column to use a period instead of a comma
            if (dataGridView1.Columns["Amount"] != null)
            {
                dataGridView1.Columns["Amount"].DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
                dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "N2";
            }

            // Apply additional formatting for a better look and feel
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F);
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        }


        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount) && amount > 0)
            {
                string reason = txtReason.Text;

                StaffTransactionBLL transaction = new StaffTransactionBLL
                {
                    UserId = selectedUserId,
                    Amount = amount,
                    Reason = reason,
                    TransactionDate = DateTime.Now,
                    TransactionType = "Withdraw"
                };

                bool isSuccess = transactionService.InsertTransaction(transaction);
                if (isSuccess)
                {
                    decimal remainingAmount = decimal.TryParse(lblRemainingSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedRemainingAmount) ? parsedRemainingAmount : 0;
                    decimal newSalary = remainingAmount == 0 ? decimal.TryParse(lblEmpSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedSalary) ? parsedSalary - amount : 0 : remainingAmount - amount;
                    LoadTransactions();
                    lblRemainingSalary.Text = newSalary.ToString(CultureInfo.InvariantCulture);
                    MessageBox.Show("Amount withdrawn successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to withdraw amount.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void btnCarryForward_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(lblEmpSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentSalary) && decimal.TryParse(lblRemainingSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal remainingSalary))
            {
                decimal newSalary = currentSalary + remainingSalary;
                userService.UpdateUserSalary(selectedUserId, newSalary);
                GetUserSalary(new UserBLL() { id = selectedUserId });
                MessageBox.Show("Salary carried forward successfully.");
            }
            else
            {
                MessageBox.Show("Failed to carry forward salary.");
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(lblRemainingSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal remainingAmount))
            {
                StaffTransactionBLL transaction = new StaffTransactionBLL
                {
                    UserId = selectedUserId,
                    Amount = remainingAmount,
                    Reason = "Paid",
                    TransactionDate = DateTime.Now,
                    TransactionType = "Salary Withdraw"
                };

                bool isSuccess = transactionService.InsertTransaction(transaction);
                if (isSuccess)
                {
                    userService.UpdateUserSalary(selectedUserId, 0);
                    GetUserSalary(new UserBLL() { id= selectedUserId});
                    MessageBox.Show("Salary settled successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to settle salary.");
                }
            }
            else
            {
                MessageBox.Show("Failed to settle salary.");
            }
        }

        private decimal CalculateRemainingSalary()
        {
            decimal totalAmount = 0;
            decimal salary = decimal.TryParse(lblEmpSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedSalary) ? parsedSalary : 0;
            int lastSalaryWithdrawIndex = -1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells["Transaction Type"].Value) == "Salary Withdraw")
                {
                    lastSalaryWithdrawIndex = i;
                }
            }

            for (int i = lastSalaryWithdrawIndex + 1; i < dataGridView1.Rows.Count; i++)
            {
                if (decimal.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells["Amount"].Value), out decimal amount))
                {
                    totalAmount += amount;
                }
            }

            return salary - totalAmount;
        }
    }
}
