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

namespace CarRental.Transactions
{
    public partial class frmAddUpdateTransaction : Form
    {
        public enum EnMode { Add  = 1 , Update = 2}
        public EnMode Mode = EnMode.Add;

        public ClsTransaction _Transaction;
        public int TransactionID;

        public frmAddUpdateTransaction()
        {
            InitializeComponent();
        }

        private void txtBookingID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookingID_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txtBookingID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBookingID, " This Faied Is Requried");
                    
            }else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBookingID, null);
            }

            int BookingID = int.Parse(txtBookingID.Text);

            ClsBooking booking = ClsBooking.GetBookingByID(BookingID);
            if(booking == null)
            {
                MessageBox.Show("No Booking With ID [" + BookingID + "]");

                errorProvider1.SetError(txtBookingID, "Check booking ID");

            }
        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            _Transaction = new ClsTransaction();

            _Transaction.BookingID = int.Parse(txtBookingID.Text);
            _Transaction.TransactionDate = dtpTransactionDate.Value;
            _Transaction.PaymentDetails = txtPaymentDetails.Text;
            _Transaction.PaidInitialTotalDueAmount = decimal.Parse(txtPaidInitinalTotalAmount.Text);

            if(_Transaction.Save())
            {
                TransactionID = _Transaction.TransactionID;
                MessageBox.Show("Data Saved Sucessfuly with TransactionID ["+TransactionID+"]", "Success");
                return;
            }
            else
            {
                MessageBox.Show("Failed In Saved Data", "Failed");
            }

        }
    }
}
