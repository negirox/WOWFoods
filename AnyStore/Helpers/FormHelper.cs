using System;
using System.Drawing;
using System.Windows.Forms;
public class FormHelper
{

    public FormHelper()
	{
	}
    public void Clear(Form form)
    {
        foreach (Control control in form.Controls)
        {
            if (control is TextBox)
            {
                ((TextBox)control).Clear();
            }
            else if (control is ComboBox)
            {
                ((ComboBox)control).SelectedIndex = -1;
            }
            else if (control is DateTimePicker)
            {
                ((DateTimePicker)control).Value = DateTime.Now;
            }
            else if (control is PictureBox)
            {
                ((PictureBox)control).Image = null;
            }
            else if (control is CheckBox)
            {
                ((CheckBox)control).Checked = false;
            }
            else if (control is RadioButton)
            {
                ((RadioButton)control).Checked = false;
            }
            else if (control is NumericUpDown)
            {
                ((NumericUpDown)control).Value = 0;
            }
        }
    }

    public void FormateDataGridView(DataGridView dataGridView)
    {
        // Set the background color
        dataGridView.BackgroundColor = Color.White;

        // Set the grid color
        dataGridView.GridColor = Color.LightGray;

        // Set the default cell style
        dataGridView.DefaultCellStyle.BackColor = Color.Beige;
        dataGridView.DefaultCellStyle.Font = new Font("Arial", 10);
        dataGridView.DefaultCellStyle.ForeColor = Color.Black;
        dataGridView.DefaultCellStyle.SelectionBackColor = Color.CadetBlue;
        dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

        // Set the column header style
        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        // Set the row header style
        dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Navy;
        dataGridView.RowHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White;

        // Set the alternating row style
        dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

        // Set the border style
        dataGridView.BorderStyle = BorderStyle.Fixed3D;

        // Set the row template height
        dataGridView.RowTemplate.Height = 30;

        // Enable column resizing
        dataGridView.AllowUserToResizeColumns = true;

        // Enable row resizing
        dataGridView.AllowUserToResizeRows = true;
    }

}
