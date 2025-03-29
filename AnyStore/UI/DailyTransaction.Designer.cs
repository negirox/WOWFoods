namespace AnyStore.UI
{
    partial class DailyTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblEmpSalary = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDailyAmount = new System.Windows.Forms.Label();
            this.btnWithDraw = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSettle = new System.Windows.Forms.Button();
            this.btnCarryForward = new System.Windows.Forms.Button();
            this.lblRemainingSalary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(81, 65);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(113, 28);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Select User";
            // 
            // cmbSearch
            // 
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(263, 60);
            this.cmbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(165, 36);
            this.cmbSearch.TabIndex = 1;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(81, 121);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(140, 28);
            this.lblSalary.TabIndex = 2;
            this.lblSalary.Text = "Current Salary";
            // 
            // lblEmpSalary
            // 
            this.lblEmpSalary.AutoSize = true;
            this.lblEmpSalary.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpSalary.Location = new System.Drawing.Point(277, 121);
            this.lblEmpSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpSalary.Name = "lblEmpSalary";
            this.lblEmpSalary.Size = new System.Drawing.Size(0, 40);
            this.lblEmpSalary.TabIndex = 3;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(263, 214);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(177, 34);
            this.txtAmount.TabIndex = 4;
            // 
            // lblDailyAmount
            // 
            this.lblDailyAmount.AutoSize = true;
            this.lblDailyAmount.Location = new System.Drawing.Point(81, 217);
            this.lblDailyAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDailyAmount.Name = "lblDailyAmount";
            this.lblDailyAmount.Size = new System.Drawing.Size(99, 28);
            this.lblDailyAmount.TabIndex = 5;
            this.lblDailyAmount.Text = "Withdraw";
            // 
            // btnWithDraw
            // 
            this.btnWithDraw.BackColor = System.Drawing.Color.Olive;
            this.btnWithDraw.Location = new System.Drawing.Point(19, 465);
            this.btnWithDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWithDraw.Name = "btnWithDraw";
            this.btnWithDraw.Size = new System.Drawing.Size(165, 46);
            this.btnWithDraw.TabIndex = 6;
            this.btnWithDraw.Text = "Withdraw";
            this.btnWithDraw.UseVisualStyleBackColor = false;
            this.btnWithDraw.Click += new System.EventHandler(this.btnWithDraw_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(558, 21);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(937, 504);
            this.dataGridView1.TabIndex = 7;
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(81, 163);
            this.lblRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(168, 28);
            this.lblRemaining.TabIndex = 8;
            this.lblRemaining.Text = "Remaining Salary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 281);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(263, 281);
            this.txtReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(209, 151);
            this.txtReason.TabIndex = 10;
            // 
            // btnSettle
            // 
            this.btnSettle.BackColor = System.Drawing.Color.Gold;
            this.btnSettle.Location = new System.Drawing.Point(192, 465);
            this.btnSettle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSettle.Name = "btnSettle";
            this.btnSettle.Size = new System.Drawing.Size(137, 46);
            this.btnSettle.TabIndex = 11;
            this.btnSettle.Text = "Settle";
            this.btnSettle.UseVisualStyleBackColor = false;
            this.btnSettle.Click += new System.EventHandler(this.btnSettle_Click);
            // 
            // btnCarryForward
            // 
            this.btnCarryForward.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCarryForward.Location = new System.Drawing.Point(350, 465);
            this.btnCarryForward.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCarryForward.Name = "btnCarryForward";
            this.btnCarryForward.Size = new System.Drawing.Size(170, 46);
            this.btnCarryForward.TabIndex = 12;
            this.btnCarryForward.Text = "Carry Forward";
            this.btnCarryForward.UseVisualStyleBackColor = false;
            this.btnCarryForward.Click += new System.EventHandler(this.btnCarryForward_Click);
            // 
            // lblRemainingSalary
            // 
            this.lblRemainingSalary.AutoSize = true;
            this.lblRemainingSalary.Location = new System.Drawing.Point(268, 163);
            this.lblRemainingSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemainingSalary.Name = "lblRemainingSalary";
            this.lblRemainingSalary.Size = new System.Drawing.Size(0, 28);
            this.lblRemainingSalary.TabIndex = 13;
            // 
            // DailyTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1508, 604);
            this.Controls.Add(this.lblRemainingSalary);
            this.Controls.Add(this.btnCarryForward);
            this.Controls.Add(this.btnSettle);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnWithDraw);
            this.Controls.Add(this.lblDailyAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblEmpSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.lblUser);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DailyTransaction";
            this.Text = "DailyTransaction";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblEmpSalary;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDailyAmount;
        private System.Windows.Forms.Button btnWithDraw;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSettle;
        private System.Windows.Forms.Button btnCarryForward;
        private System.Windows.Forms.Label lblRemainingSalary;
    }
}