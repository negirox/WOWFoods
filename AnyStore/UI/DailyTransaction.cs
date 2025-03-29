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
            lblEmpSalary.Text = (user.userSalary ?? "0").ToString(CultureInfo.InvariantCulture);
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
            dataGridView1.DataSource = dt;
            // Format the Amount column to use a period instead of a comma
            if (dataGridView1.Columns["Amount"] != null)
            {
                dataGridView1.Columns["Amount"].DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
                dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "N2";
            }
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
                lblEmpSalary.Text = newSalary.ToString(CultureInfo.InvariantCulture);
                lblRemainingSalary.Text = "0"; // Reset remaining salary
                MessageBox.Show("Salary carried forward successfully.");
                UserBLL user = userService.GetUser(selectedUserId);
                GetUserSalary(user);
            }
            else
            {
                MessageBox.Show("Failed to carry forward salary.");
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(lblEmpSalary.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal remainingAmount))
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
                    lblEmpSalary.Text = "0";
                    lblRemainingSalary.Text = "0"; // Reset remaining salary
                    LoadTransactions();
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
                if (Convert.ToString(dataGridView1.Rows[i].Cells["TransactionType"].Value) == "Salary Withdraw")
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
