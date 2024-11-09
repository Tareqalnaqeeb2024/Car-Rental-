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
    public partial class frmShowCustomerInfo : Form
    {
        public int _CustomerID = -1;
        public ClsCustomer _Customer ;
        
        public frmShowCustomerInfo( int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;

        }

        private void frmShowCustomerInfo_Load(object sender, EventArgs e)
        {

            ctrlCustomerCard1.LoadCustomerInfo(_CustomerID);
        }

        private void ctrlCustomerCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
