namespace AnyStore.UI
{
    partial class frmChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.cmbIntervalType = new System.Windows.Forms.ComboBox();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransaction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartTransaction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPanel
            // 
            this.chartPanel.BackColor = System.Drawing.Color.GreenYellow;
            this.chartPanel.Controls.Add(this.chartTransaction);
            this.chartPanel.Controls.Add(this.label2);
            this.chartPanel.Controls.Add(this.label1);
            this.chartPanel.Controls.Add(this.lblTransaction);
            this.chartPanel.Controls.Add(this.toDate);
            this.chartPanel.Controls.Add(this.fromDate);
            this.chartPanel.Controls.Add(this.cmbIntervalType);
            this.chartPanel.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPanel.Location = new System.Drawing.Point(26, 32);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(984, 479);
            this.chartPanel.TabIndex = 0;
            // 
            // cmbIntervalType
            // 
            this.cmbIntervalType.FormattingEnabled = true;
            this.cmbIntervalType.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly",
            "Custom"});
            this.cmbIntervalType.Location = new System.Drawing.Point(151, 28);
            this.cmbIntervalType.Name = "cmbIntervalType";
            this.cmbIntervalType.Size = new System.Drawing.Size(141, 31);
            this.cmbIntervalType.TabIndex = 0;
            this.cmbIntervalType.SelectedIndexChanged += new System.EventHandler(this.cmbIntervalType_SelectedIndexChanged);
            // 
            // fromDate
            // 
            this.fromDate.Enabled = false;
            this.fromDate.Location = new System.Drawing.Point(357, 28);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(286, 30);
            this.fromDate.TabIndex = 1;
            // 
            // toDate
            // 
            this.toDate.Enabled = false;
            this.toDate.Location = new System.Drawing.Point(697, 31);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(269, 30);
            this.toDate.TabIndex = 2;
            // 
            // lblTransaction
            // 
            this.lblTransaction.AutoSize = true;
            this.lblTransaction.Location = new System.Drawing.Point(3, 31);
            this.lblTransaction.Name = "lblTransaction";
            this.lblTransaction.Size = new System.Drawing.Size(137, 23);
            this.lblTransaction.TabIndex = 3;
            this.lblTransaction.Text = "Transaction Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(649, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chartTransaction
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTransaction.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTransaction.Legends.Add(legend2);
            this.chartTransaction.Location = new System.Drawing.Point(16, 95);
            this.chartTransaction.Name = "chartTransaction";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTransaction.Series.Add(series2);
            this.chartTransaction.Size = new System.Drawing.Size(833, 355);
            this.chartTransaction.TabIndex = 6;
            this.chartTransaction.Text = "Transaction Report";
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 523);
            this.Controls.Add(this.chartPanel);
            this.Name = "frmChart";
            this.Text = "frmChart";
            this.chartPanel.ResumeLayout(false);
            this.chartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTransaction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Label lblTransaction;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.ComboBox cmbIntervalType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTransaction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}