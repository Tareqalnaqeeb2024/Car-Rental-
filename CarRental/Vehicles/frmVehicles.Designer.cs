
namespace CarRental.Vehicles
{
    partial class frmVehicles
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
            this.btnFind = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSereach = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNewVehicle = new System.Windows.Forms.Button();
            this.btnShowListVehicles = new System.Windows.Forms.Button();
            this.btnFindVehicleInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNationalID = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDriverLicense = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowListBookings = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddNewReturnVehicle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(414, 139);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 33;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(684, 259);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtSereach
            // 
            this.txtSereach.Location = new System.Drawing.Point(531, 182);
            this.txtSereach.Name = "txtSereach";
            this.txtSereach.Size = new System.Drawing.Size(109, 24);
            this.txtSereach.TabIndex = 31;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AutoSize = true;
            this.txtCustomerID.Location = new System.Drawing.Point(447, 56);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(112, 17);
            this.txtCustomerID.TabIndex = 30;
            this.txtCustomerID.Text = "New CustomerID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAddNewVehicle
            // 
            this.btnAddNewVehicle.Location = new System.Drawing.Point(79, 378);
            this.btnAddNewVehicle.Name = "btnAddNewVehicle";
            this.btnAddNewVehicle.Size = new System.Drawing.Size(169, 73);
            this.btnAddNewVehicle.TabIndex = 34;
            this.btnAddNewVehicle.Text = "AddNewVehicle";
            this.btnAddNewVehicle.UseVisualStyleBackColor = true;
            this.btnAddNewVehicle.Click += new System.EventHandler(this.btnAddNewVehicle_Click);
            // 
            // btnShowListVehicles
            // 
            this.btnShowListVehicles.Location = new System.Drawing.Point(565, 318);
            this.btnShowListVehicles.Name = "btnShowListVehicles";
            this.btnShowListVehicles.Size = new System.Drawing.Size(169, 73);
            this.btnShowListVehicles.TabIndex = 35;
            this.btnShowListVehicles.Text = "ShowListVehicle";
            this.btnShowListVehicles.UseVisualStyleBackColor = true;
            this.btnShowListVehicles.Click += new System.EventHandler(this.btnShowListVehicles_Click);
            // 
            // btnFindVehicleInfo
            // 
            this.btnFindVehicleInfo.Location = new System.Drawing.Point(342, 218);
            this.btnFindVehicleInfo.Name = "btnFindVehicleInfo";
            this.btnFindVehicleInfo.Size = new System.Drawing.Size(169, 73);
            this.btnFindVehicleInfo.TabIndex = 36;
            this.btnFindVehicleInfo.Text = "FindVehicleInfo";
            this.btnFindVehicleInfo.UseVisualStyleBackColor = true;
            this.btnFindVehicleInfo.Click += new System.EventHandler(this.btnFindVehicleInfo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(565, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 73);
            this.button1.TabIndex = 37;
            this.button1.Text = "ShowListCustomers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(109, 24);
            this.txtName.TabIndex = 17;
            // 
            // txtNationalID
            // 
            this.txtNationalID.Location = new System.Drawing.Point(95, 121);
            this.txtNationalID.Name = "txtNationalID";
            this.txtNationalID.Size = new System.Drawing.Size(109, 24);
            this.txtNationalID.TabIndex = 18;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(95, 172);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(109, 24);
            this.txtAddress.TabIndex = 19;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(95, 227);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(109, 24);
            this.txtPhone.TabIndex = 20;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(95, 277);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(109, 24);
            this.txtEmail.TabIndex = 21;
            // 
            // txtDriverLicense
            // 
            this.txtDriverLicense.Location = new System.Drawing.Point(95, 318);
            this.txtDriverLicense.Name = "txtDriverLicense";
            this.txtDriverLicense.Size = new System.Drawing.Size(109, 24);
            this.txtDriverLicense.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "NationalID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "DriverLicense";
            // 
            // btnShowListBookings
            // 
            this.btnShowListBookings.Location = new System.Drawing.Point(342, 318);
            this.btnShowListBookings.Name = "btnShowListBookings";
            this.btnShowListBookings.Size = new System.Drawing.Size(169, 73);
            this.btnShowListBookings.TabIndex = 38;
            this.btnShowListBookings.Text = "ShowListBookings";
            this.btnShowListBookings.UseVisualStyleBackColor = true;
            this.btnShowListBookings.Click += new System.EventHandler(this.btnShowListBookings_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 73);
            this.button2.TabIndex = 39;
            this.button2.Text = "ShowAddNewBooking";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddNewReturnVehicle
            // 
            this.btnAddNewReturnVehicle.Location = new System.Drawing.Point(774, 66);
            this.btnAddNewReturnVehicle.Name = "btnAddNewReturnVehicle";
            this.btnAddNewReturnVehicle.Size = new System.Drawing.Size(202, 73);
            this.btnAddNewReturnVehicle.TabIndex = 40;
            this.btnAddNewReturnVehicle.Text = "ShowAddNewReturnVehicle";
            this.btnAddNewReturnVehicle.UseVisualStyleBackColor = true;
            this.btnAddNewReturnVehicle.Click += new System.EventHandler(this.btnAddNewReturnVehicle_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(791, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 73);
            this.button3.TabIndex = 41;
            this.button3.Text = "ShowVehicleReturnList";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 737);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAddNewReturnVehicle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnShowListBookings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFindVehicleInfo);
            this.Controls.Add(this.btnShowListVehicles);
            this.Controls.Add(this.btnAddNewVehicle);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtSereach);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDriverLicense);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtNationalID);
            this.Controls.Add(this.txtName);
            this.Name = "frmVehicles";
            this.Text = "frmVehicles";
            this.Load += new System.EventHandler(this.frmVehicles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtSereach;
        private System.Windows.Forms.Label txtCustomerID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddNewVehicle;
        private System.Windows.Forms.Button btnShowListVehicles;
        private System.Windows.Forms.Button btnFindVehicleInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNationalID;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDriverLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShowListBookings;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddNewReturnVehicle;
        private System.Windows.Forms.Button button3;
    }
}