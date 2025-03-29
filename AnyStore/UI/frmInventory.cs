using Store.Repository.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using CategoriesDAL = Store.Repository.Repository.CategoriesDAL;

namespace AnyStore.UI
{
    public partial class frmInventory : Form
    {
        private readonly CategoriesDAL cdal = new CategoriesDAL();
        private readonly ProductsDAL pdal = new ProductsDAL();
        private readonly FormHelper formHelper = new FormHelper();
        public frmInventory()
        {
            InitializeComponent();
            formHelper.FormateDataGridView(dgvProducts);
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Addd Functionality to Close this form
            this.Close();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //Display the CAtegories in Combobox
            DataTable cDt = cdal.Select();

            cmbCategories.DataSource = cDt;

            //Give the Value member and display member for Combobox
            cmbCategories.DisplayMember = "title";
            cmbCategories.ValueMember = "title";

            //Display all the products in Datagrid view when the form is loaded
            DataTable pdt = pdal.Select();
            dgvProducts.DataSource = pdt;
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display all the Products Based on Selected CAtegory

            string category = cmbCategories.Text;

            DataTable dt = pdal.DisplayProductsByCategory(category);
            dgvProducts.DataSource = dt;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //Display all the productswhen this button is clicked
            DataTable dt = pdal.Select();
            dgvProducts.DataSource = dt;
        }
    }
}
