using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusiness;
using CarRental.GlobalCalsses;

namespace CarRental.Customers
{
    public partial class frmAddUpdateCustomers : Form
    {
        public enum EnMode { Add = 1 , Update =2};
        public EnMode Mode;
        public ClsCustomer _Customer;
        public int _CustomerID = -1;

        public frmAddUpdateCustomers()
        {

            InitializeComponent();
            Mode = EnMode.Add;

        }

        public frmAddUpdateCustomers(int CustomerID)
        {
           
            InitializeComponent();

            _CustomerID = CustomerID;

            LoadCustomerInfo();

            Mode = EnMode.Update; 

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


           // pbCustomerImage.Image = Properties.Resources.Addcustomer2;
            _Customer.Name = txtName.Text;
            _Customer.NationalID = txtNationalID.Text;
            _Customer.Phone = int.Parse(txtPhone.Text);
            _Customer.Email = txtEmail.Text;
            _Customer.Address = txtAddress.Text;
            _Customer.DriverLicense = int.Parse(txtDriverLicense.Text);

            if(_Customer.Save())
            {
                MessageBox.Show("Data Saved Successfuly with CustomerID"+_Customer.CustomerID.ToString() , "Success");
                lbCustomerID.Text = _Customer.CustomerID.ToString();
                Mode = EnMode.Update;
                lbTitle.Text = " Update Customer ";
                return;
            }
            else
            {
                MessageBox.Show("Error Failed", "Errors");
            }

        }

        private void frmAddUpdateCustomers_Load(object sender, EventArgs e)
        {

            ResetDefultValue();

            if (Mode == EnMode.Update)

                LoadCustomerInfo();

        }

        private void ResetDefultValue()
        {

            if(Mode == EnMode.Add)
            {
                lbTitle.Text = "Add New Customer";
                _Customer = new ClsCustomer();
            }
            else
            {
                lbTitle.Text = " Update Customer";
            }


        }

        public void LoadCustomerInfo()
        {
             _Customer = ClsCustomer.GetCustomerByID(_CustomerID);
            if(_Customer == null)
            {
                MessageBox.Show(" No Customer ");
                this.Close();
                return;
                
            }
            else
            {
                lbTitle.Text = " Update Customer ";
               // pbCustomerImage.Image = Properties.Resources.UpdateCustomer2;
                lbCustomerID.Text = _Customer.CustomerID.ToString();
                txtName.Text = _Customer.Name;
                txtNationalID.Text = _Customer.NationalID;
                txtPhone.Text = _Customer.Phone.ToString();
                txtEmail.Text = _Customer.Email;
                txtAddress.Text = _Customer.Address;
                txtDriverLicense.Text = _Customer.DriverLicense.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void ValidatingTextBoxes(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox) sender;


            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, " This faild Is Requried");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtEmail, " This Failed is Requreid");

            }

            else if(!ClsFormat.ValidatingEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, " Wrong in Format ");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }
    }
}
