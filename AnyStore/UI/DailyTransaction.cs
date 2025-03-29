using System;
using System.Data;
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
                user = userService.GetUser(user.id);
                selectedUserId = user.id;
                lblEmpSalary.Text = user.userSalary ?? "0";
                lblRemainingSalary.Text = user.userSalary ?? "0"; // Initialize remaining salary
                LoadTransactions();
            }
        }

        private void LoadTransactions()
        {
            DataTable dt = transactionService.GetTransactionsByUserId(selectedUserId);
            dataGridView1.DataSource = dt;
        }

        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && amount > 0)
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
                    decimal remainingAmount = decimal.TryParse(lblRemainingSalary.Text, out decimal parsedRemainingAmount) ? parsedRemainingAmount : 0;
                    decimal newSalary = remainingAmount == 0 ? decimal.TryParse(lblEmpSalary.Text, out decimal parsedSalary) ? parsedSalary - amount : 0 : remainingAmount - amount;
                    LoadTransactions();
                    lblRemainingSalary.Text = newSalary.ToString();
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
            if (decimal.TryParse(lblEmpSalary.Text, out decimal currentSalary) && decimal.TryParse(lblRemainingSalary.Text, out decimal remainingSalary))
            {
                decimal newSalary = currentSalary + remainingSalary;
                userService.UpdateUserSalary(selectedUserId, newSalary);
                lblEmpSalary.Text = newSalary.ToString();
                lblRemainingSalary.Text = "0"; // Reset remaining salary
                MessageBox.Show("Salary carried forward successfully.");
            }
            else
            {
                MessageBox.Show("Failed to carry forward salary.");
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(lblEmpSalary.Text, out decimal remainingAmount))
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
    }
}
