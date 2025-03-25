using DGVPrinterHelper;
using Store.Models.BLL;
using Store.Repository.Repository;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Transactions;
using System.Windows.Forms;
using AnyStore.Helpers;

namespace AnyStore.UI
{
    public partial class frmPurchaseAndSales : Form
    {
        DeaCustDAL dcDAL = new DeaCustDAL();
        productsDAL pDAL = new productsDAL();
        UserDAL uDAL = new UserDAL();
        TransactionDAL tDAL = new TransactionDAL();
        TransactionDetailDAL tdDAL = new TransactionDetailDAL();

        DataTable transactionDT = new DataTable();
        FormHelper formHelper = new FormHelper();
        public frmPurchaseAndSales()
        {
            InitializeComponent();
            formHelper.FormateDataGridView(dgvAddedProducts);
            this.WindowState = FormWindowState.Normal;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmPurchaseAndSales_Load(object sender, EventArgs e)
        {
            //Get the transactionType value from frmUserDashboard
            string type = frmUserDashboard.transactionType;
            //Set the value on lblTop
            lblTop.Text = type;

            //Specify Columns for our TransactionDataTable
            transactionDT.Columns.Add("Product Name", typeof(string));
            transactionDT.Columns.Add("Rate", typeof(decimal));
            transactionDT.Columns.Add("Quantity", typeof(decimal));
            transactionDT.Columns.Add("Total", typeof(decimal));


            // Populate ComboBoxes
            LoadDealerCustomerComboBox();
            LoadProductComboBox();
        }

        private void LoadDealerCustomerComboBox()
        {
            DataTable dt = dcDAL.Select();
            cmbSearch.DataSource = dt;
            cmbSearch.DisplayMember = "name";
            cmbSearch.ValueMember = "id";
            cmbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadProductComboBox()
        {
            DataTable dt = pDAL.Select();
            cmbSearchProduct.DataSource = dt;
            cmbSearchProduct.DisplayMember = "name";
            cmbSearchProduct.ValueMember = "id";
            cmbSearchProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSearchProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword fro the text box
            string keyword = txtSearch.Text;

            if (keyword == "")
            {
                //Clear all the textboxes
                txtName.Text = "";
                txtEmail.Text = "";
                txtContact.Text = "";
                txtAddress.Text = "";
                return;
            }

            //Write the code to get the details and set the value on text boxes
            DeaCustBLL dc = dcDAL.SearchDealerCustomerForTransaction(keyword);

            //Now transfer or set the value from DeCustBLL to textboxes
            txtName.Text = dc.name;
            txtEmail.Text = dc.email;
            txtContact.Text = dc.contact;
            txtAddress.Text = dc.address;
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword from productsearch textbox
            string keyword = txtSearchProduct.Text;

            //Check if we have value to txtSearchProduct or not
            if (keyword == "")
            {
                txtProductName.Text = "";
                txtInventory.Text = "";
                txtRate.Text = "";
                TxtQty.Text = "";
                return;
            }

            //Search the product and display on respective textboxes
            ProductsBLL p = pDAL.GetProductsForTransaction(keyword);

            //Set the values on textboxes based on p object
            txtProductName.Text = p.name;
            txtInventory.Text = p.qty.ToString(CultureInfo.InvariantCulture);
            txtRate.Text = p.rate.ToString(CultureInfo.InvariantCulture);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!ValidationHelper.IsNotEmpty(txtProductName.Text) ||
                !ValidationHelper.IsValidDecimal(txtRate.Text) ||
                !ValidationHelper.IsValidDecimal(TxtQty.Text))
            {
                MessageBox.Show("Please enter valid product details.");
                return;
            }

            //Get Product Name, Rate and Qty customer wants to buy
            string productName = txtProductName.Text;
            decimal Rate = decimal.Parse(txtRate.Text, CultureInfo.InvariantCulture);
            decimal Qty = decimal.Parse(TxtQty.Text, CultureInfo.InvariantCulture);

            decimal Total = Rate * Qty; //Total=RatexQty

            //Display the Subtotal in textbox
            //Get the subtotal value from textbox
            decimal subTotal = decimal.Parse(txtSubTotal.Text, CultureInfo.InvariantCulture);
            subTotal = subTotal + Total;

            //Check whether the product is selected or not
            if (productName == "")
            {
                //Display error MEssage
                MessageBox.Show("Select the product first. Try Again.");
            }
            else
            {
                //Add product to the dAta Grid View
                transactionDT.Rows.Add(productName, Rate.ToString(CultureInfo.InvariantCulture), Qty.ToString(CultureInfo.InvariantCulture), Total.ToString(CultureInfo.InvariantCulture));

                //Show in DAta Grid View
                dgvAddedProducts.DataSource = transactionDT;
                //Display the Subtotal in textbox
                txtSubTotal.Text = subTotal.ToString(CultureInfo.InvariantCulture);

                //Clear the Textboxes
                txtSearchProduct.Text = "";
                txtProductName.Text = "";
                txtInventory.Text = "0.00";
                txtRate.Text = "0.00";
                TxtQty.Text = "0.00";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidationHelper.IsValidDecimal(txtDiscount.Text))
            {
                MessageBox.Show("Please enter a valid discount.");
                return;
            }

            //Get the value fro discount textbox
            string value = txtDiscount.Text;

            if (value == "")
            {
                //Display Error Message
                MessageBox.Show("Please Add Discount First");
            }
            else
            {
                //Get the discount in decimal value
                decimal subTotal = decimal.Parse(txtSubTotal.Text, CultureInfo.InvariantCulture);
                decimal discount = decimal.Parse(txtDiscount.Text, CultureInfo.InvariantCulture);

                //Calculate the grandtotal based on discount
                decimal grandTotal = ((100 - discount) / 100) * subTotal;

                //Display the GrandTotla in TextBox
                txtGrandTotal.Text = grandTotal.ToString(CultureInfo.InvariantCulture);
            }

        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidationHelper.IsValidDecimal(txtVat.Text))
            {
                MessageBox.Show("Please enter a valid VAT.");
                return;
            }

            //Check if the grandTotal has value or not if it has not value then calculate the discount first
            string check = txtGrandTotal.Text;
            if (check == "")
            {
                //Deisplay the error message to calcuate discount
                MessageBox.Show("Calculate the discount and set the Grand Total First.");
            }
            else
            {
                //Calculate VAT
                //Getting the VAT Percent first
                decimal previousGT = decimal.Parse(txtGrandTotal.Text, CultureInfo.InvariantCulture);
                decimal vat = decimal.Parse(txtVat.Text, CultureInfo.InvariantCulture);
                decimal grandTotalWithVAT = ((100 + vat) / 100) * previousGT;

                //Displaying new grand total with vat
                txtGrandTotal.Text = grandTotalWithVAT.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidationHelper.IsValidDecimal(txtPaidAmount.Text))
            {
                MessageBox.Show("Please enter a valid paid amount.");
                return;
            }

            //Get the paid amount and grand total
            decimal grandTotal = decimal.Parse(txtGrandTotal.Text, CultureInfo.InvariantCulture);
            decimal paidAmount = decimal.Parse(txtPaidAmount.Text, CultureInfo.InvariantCulture);

            decimal returnAmount = paidAmount - grandTotal;

            //Display the return amount as well
            txtReturnAmount.Text = returnAmount.ToString(CultureInfo.InvariantCulture);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!ValidationHelper.IsNotEmpty(txtName.Text) ||
                !ValidationHelper.IsValidDecimal(txtGrandTotal.Text) ||
                !ValidationHelper.IsValidDecimal(txtVat.Text) ||
                !ValidationHelper.IsValidDecimal(txtDiscount.Text))
            {
                MessageBox.Show("Please enter valid transaction details.");
                return;
            }

            //Get the Values from PurchaseSales Form First
            TransactionsBLL transaction = new TransactionsBLL();

            transaction.type = lblTop.Text;

            //Get the ID of Dealer or Customer Here
            //Lets get name of the dealer or customer first
            string deaCustName = txtName.Text;
            DeaCustBLL dc = dcDAL.GetDeaCustIDFromName(deaCustName);

            transaction.dea_cust_id = dc.id;
            transaction.grandTotal = Math.Round(decimal.Parse(txtGrandTotal.Text, CultureInfo.InvariantCulture), 2);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(txtVat.Text, CultureInfo.InvariantCulture);
            transaction.discount = decimal.Parse(txtDiscount.Text, CultureInfo.InvariantCulture);

            //Get the Username of Logged in user
            string username = frmLogin.loggedIn;
            UserBLL u = uDAL.GetIDFromUsername(username);

            transaction.added_by = u.id;
            transaction.transactionDetails = transactionDT;

            //Lets Create a Boolean Variable and set its value to false
            bool success = false;

            //Actual Code to Insert Transaction And Transaction Details
            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;
                //Create aboolean value and insert transaction 
                bool w = tDAL.Insert_Transaction(transaction, out transactionID);

                //Use for loop to insert Transaction Details
                for (int i = 0; i < transactionDT.Rows.Count; i++)
                {
                    //Get all the details of the product
                    TransactionDetailBLL transactionDetail = new TransactionDetailBLL();
                    //Get the Product name and convert it to id
                    string ProductName = transactionDT.Rows[i][0].ToString();
                    ProductsBLL p = pDAL.GetProductIDFromName(ProductName);

                    transactionDetail.product_id = p.id;
                    transactionDetail.rate = decimal.Parse(transactionDT.Rows[i][1].ToString(), CultureInfo.InvariantCulture);
                    transactionDetail.qty = decimal.Parse(transactionDT.Rows[i][2].ToString(), CultureInfo.InvariantCulture);
                    transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString(), CultureInfo.InvariantCulture), 2);
                    transactionDetail.dea_cust_id = dc.id;
                    transactionDetail.added_date = DateTime.Now;
                    transactionDetail.added_by = u.id;

                    //Here Increase or Decrease Product Quantity based on Purchase or sales
                    string transactionType = lblTop.Text;

                    //Lets check whether we are on Purchase or Sales
                    bool x = false;
                    if (transactionType == "Purchase")
                    {
                        //Increase the Product
                        x = pDAL.IncreaseProduct(transactionDetail.product_id, transactionDetail.qty);
                    }
                    else if (transactionType == "Sales")
                    {
                        //Decrease the Product Quntiyt
                        x = pDAL.DecreaseProduct(transactionDetail.product_id, transactionDetail.qty);
                    }

                    //Insert Transaction Details inside the database
                    bool y = tdDAL.InsertTransactionDetail(transactionDetail);
                    success = w && x && y;
                }

                if (success == true)
                {
                    //Transaction Complete
                    scope.Complete();
                }
                else
                {
                    //Transaction Failed
                    MessageBox.Show("Transaction Failed");
                }
            }
        }

        private void PrintBill()
        {

            //Code to Print Bill
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "\r\n\r\n\r\n WOW FOODS \r\n\r\n";
            printer.SubTitle = "";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Discount: " + txtDiscount.Text + "% \r\n" + "VAT: " + txtVat.Text + "% \r\n" + "Grand Total: " + txtGrandTotal.Text + "\r\n\r\n" + "Thank you for doing business with us.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvAddedProducts);

            MessageBox.Show("Transaction Completed Sucessfully");
            //Celar the Data Grid View and Clear all the TExtboxes
            dgvAddedProducts.DataSource = null;
            dgvAddedProducts.Rows.Clear();

            txtSearch.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearchProduct.Text = "";
            txtProductName.Text = "";
            txtInventory.Text = "0";
            txtRate.Text = "0";
            TxtQty.Text = "0";
            txtSubTotal.Text = "0";
            txtDiscount.Text = "0";
            txtVat.Text = "0";
            txtGrandTotal.Text = "0";
            txtPaidAmount.Text = "0";
            txtReturnAmount.Text = "0";
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected value from the combo box
            string keyword = cmbSearch.Text;

            //Write the code to get the details and set the value on text boxes
            DeaCustBLL dc = dcDAL.SearchDealerCustomerForTransaction(keyword);

            //Now transfer or set the value from DeCustBLL to textboxes
            txtName.Text = dc.name;
            txtEmail.Text = dc.email;
            txtContact.Text = dc.contact;
            txtAddress.Text = dc.address;
        }

        private void cmbSearchProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected value from the combo box
            string keyword = cmbSearchProduct.Text;

            //Search the product and display on respective textboxes
            ProductsBLL p = pDAL.GetProductsForTransaction(keyword);

            //Set the values on textboxes based on p object
            txtProductName.Text = p.name;
            txtInventory.Text = p.qty.ToString(CultureInfo.InvariantCulture);
            txtRate.Text = p.rate.ToString(CultureInfo.InvariantCulture);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintBill();
        }
    }
}
