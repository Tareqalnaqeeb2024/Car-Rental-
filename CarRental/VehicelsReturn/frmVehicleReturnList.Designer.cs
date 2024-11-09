
namespace CarRental.VehicelsReturn
{
    partial class frmVehicleReturnList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterTextValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalVehiclesReturn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvVehiclesReturnList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDateilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiclesReturnList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterTextValue
            // 
            this.txtFilterTextValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterTextValue.Location = new System.Drawing.Point(373, 210);
            this.txtFilterTextValue.Name = "txtFilterTextValue";
            this.txtFilterTextValue.Size = new System.Drawing.Size(131, 27);
            this.txtFilterTextValue.TabIndex = 20;
            this.txtFilterTextValue.TextChanged += new System.EventHandler(this.txtFilterTextValue_TextChanged);
            this.txtFilterTextValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterTextValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Return ID",
            "Transaction ID",
            "Booking ID",
            "Actual Rental Days",
            "Mileage",
            "Consumed Mileage",
            "Final Check Notes",
            "Addtional Charges",
            "Actual Total Due Amount"});
            this.cbFilterBy.Location = new System.Drawing.Point(160, 206);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(193, 28);
            this.cbFilterBy.TabIndex = 19;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Filter By:";
            // 
            // lbTotalVehiclesReturn
            // 
            this.lbTotalVehiclesReturn.AutoSize = true;
            this.lbTotalVehiclesReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalVehiclesReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTotalVehiclesReturn.Location = new System.Drawing.Point(292, 623);
            this.lbTotalVehiclesReturn.Name = "lbTotalVehiclesReturn";
            this.lbTotalVehiclesReturn.Size = new System.Drawing.Size(60, 25);
            this.lbTotalVehiclesReturn.TabIndex = 17;
            this.lbTotalVehiclesReturn.Text = "????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 623);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total Vehicles Return  :";
            // 
            // dgvVehiclesReturnList
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvVehiclesReturnList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVehiclesReturnList.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehiclesReturnList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVehiclesReturnList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiclesReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVehiclesReturnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiclesReturnList.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiclesReturnList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvVehiclesReturnList.EnableHeadersVisualStyles = false;
            this.dgvVehiclesReturnList.Location = new System.Drawing.Point(44, 264);
            this.dgvVehiclesReturnList.Name = "dgvVehiclesReturnList";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiclesReturnList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvVehiclesReturnList.RowHeadersWidth = 51;
            this.dgvVehiclesReturnList.RowTemplate.Height = 26;
            this.dgvVehiclesReturnList.Size = new System.Drawing.Size(1237, 344);
            this.dgvVehiclesReturnList.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.addNewCustomerToolStripMenuItem,
            this.deleteCustomerToolStripMenuItem,
            this.showDateilsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 108);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.BackColor = System.Drawing.Color.White;
            this.btnAddVehicle.Image = global::CarRental.Properties.Resources.return__3_;
            this.btnAddVehicle.Location = new System.Drawing.Point(1161, 166);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(87, 76);
            this.btnAddVehicle.TabIndex = 15;
            this.btnAddVehicle.UseVisualStyleBackColor = false;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarRental.Properties.Resources.return__1_;
            this.pictureBox1.Location = new System.Drawing.Point(534, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::CarRental.Properties.Resources.updateCustomer1;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.updateToolStripMenuItem.Text = "Update Return";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // addNewCustomerToolStripMenuItem
            // 
            this.addNewCustomerToolStripMenuItem.Image = global::CarRental.Properties.Resources.Addcustomer__1_;
            this.addNewCustomerToolStripMenuItem.Name = "addNewCustomerToolStripMenuItem";
            this.addNewCustomerToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.addNewCustomerToolStripMenuItem.Text = "Add Return Vehicle";
            this.addNewCustomerToolStripMenuItem.Click += new System.EventHandler(this.addNewCustomerToolStripMenuItem_Click);
            // 
            // deleteCustomerToolStripMenuItem
            // 
            this.deleteCustomerToolStripMenuItem.Image = global::CarRental.Properties.Resources.deleteCus;
            this.deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
            this.deleteCustomerToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.deleteCustomerToolStripMenuItem.Text = "Delete Return";
            // 
            // showDateilsToolStripMenuItem
            // 
            this.showDateilsToolStripMenuItem.Image = global::CarRental.Properties.Resources.CustomerInfo;
            this.showDateilsToolStripMenuItem.Name = "showDateilsToolStripMenuItem";
            this.showDateilsToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.showDateilsToolStripMenuItem.Text = "Show Return";
            // 
            // frmVehicleReturnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1369, 688);
            this.Controls.Add(this.txtFilterTextValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTotalVehiclesReturn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvVehiclesReturnList);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmVehicleReturnList";
            this.Text = "frmVehicleReturnList";
            this.Load += new System.EventHandler(this.frmVehicleReturnList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiclesReturnList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterTextValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotalVehiclesReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvVehiclesReturnList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDateilsToolStripMenuItem;
    }
}