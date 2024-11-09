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

namespace CarRental.Customers
{
    public partial class ctrlCustomerCard : UserControl
    {
        private int _CutomerID = -1;
        private ClsCustomer _Customer;

        public int CustomerID
        {
            get { return _CutomerID; }
        }

        public ClsCustomer SelectedCustomerInfo
            {
            get {return _Customer;}
}
        public ctrlCustomerCard()
        {
            InitializeComponent();
        }

        private void ctrlCustomerCard_Load(object sender, EventArgs e)
        {
        }

        public void LoadCustomerInfo( int CutomerID)
        {
            _Customer = ClsCustomer.GetCustomerByID(CutomerID);

            if(_Customer ==  null)
            {
                MessageBox.Show("No Customer with ID [" + CustomerID + "]");
                return;

            }

            _FillCustomerInfo();
           
        }

        private void _FillCustomerInfo()
        {
            lbCustomerID.Text = Convert.ToString(_Customer.CustomerID);
            lbName.Text = _Customer.Name;
            lbEmail.Text = _Customer.Email;
            lbAddress.Text = _Customer.Address;
            lbDriverLincese.Text = Convert.ToString(_Customer.DriverLicense);
            lbNationalID.Text = _Customer.NationalID.ToString();
            lbPhone.Text = Convert.ToString(_Customer.Phone);
        }


    }
}
