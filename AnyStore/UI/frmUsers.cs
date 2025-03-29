using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Store.Models.BLL;
using Store.Repository.Repository;

namespace AnyStore.UI
{
    public partial class frmUsers : Form
    {
        UserBLL u = new UserBLL();
        private readonly UserDAL dal = new UserDAL();
        private byte[] imageBytes;
        private readonly FormHelper formHelper = new FormHelper();
        public frmUsers()
        {
            InitializeComponent();
            formHelper.FormateDataGridView(dgvUsers);
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Gettting Data FRom UI
            FillModelProps();
            //Inserting Data into DAtabase
            bool success = dal.Insert(u);
            //If the data is successfully inserted then the value of success will be true else it will be false
            if (success == true)
            {
                //Data Successfully Inserted
                MessageBox.Show("User successfully created.");
                ClearForm();
            }
            else
            {
                //Failed to insert data
                MessageBox.Show("Failed to add new user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void FillModelProps()
        {
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;

            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;
            u.userImage = imageBytes;
            u.aadharNo = txtAadhar.Text;
            u.userSalary = txtSalary.Text;
            //Getting Username of the logged in user
            string loggedUser = frmLogin.loggedIn;
            UserBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }
        private void ClearForm()
        {
            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
            cmbGender.SelectedIndex = 0;
            txtAadhar.Text = "";
            txtSalary.Text = "";
            pictureBoxImage.Image = null;
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();
            txtSalary.Text = dgvUsers.Rows[rowIndex].Cells[11].Value.ToString();
            txtAadhar.Text = dgvUsers.Rows[rowIndex].Cells[12].Value.ToString();
            //Get the Image from Data Grid View and display it in PictureBox
            if(dgvUsers.Rows[rowIndex].Cells[10].Value == null)
            {
                pictureBoxImage.Image = null;
                return;
            }
            byte[] img = (byte[])dgvUsers.Rows[rowIndex].Cells[10].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBoxImage.Image = Image.FromStream(ms);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from User UI
            u.id = Convert.ToInt32(txtUserID.Text);
            FillModelProps();
            //Updating Data into database
            bool success = dal.Update(u);
            //if data is updated successfully then the value of success will be true else it will be false
            if(success==true)
            {
                //Data Updated Successfully
                MessageBox.Show("User successfully updated");
                ClearForm();
            }
            else
            {
                //failed to update user
                MessageBox.Show("Failed to update user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting User ID from Form
            u.id = Convert.ToInt32(txtUserID.Text);
            bool success = dal.Delete(u);
            //if data is deleted then the value of success will be true else it will be false
            if(success==true)
            {
                //User Deleted Successfully 
                MessageBox.Show("User deleted successfully");
                ClearForm();
            }
            else
            {
                //Failed to Delete User
                MessageBox.Show("Failed to delete user");

            }
            //refreshing Datagrid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            string keywords = txtSearch.Text;

            //Chec if the keywords has value or not
            if(keywords!=null)
            {
                //Show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = ofd.FileName;
                    pictureBoxImage.Image = new Bitmap(imagePath);
                    imageBytes = File.ReadAllBytes(imagePath);
                }
            }
        }
    }
}
