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

namespace CarRental.Booking
{
    public partial class frmAddUpdateBookings : Form
    {
        public enum EnMode { Add=1 , Update=2};
        public static EnMode Mode = EnMode.Add; 
        public ClsBooking _Booking;
        public int _BookingID;
        public int TransactionID;
        public ClsTransaction _Transaction;
        public ClsVehicles _Vehicle;
        public int _VehicleID;

        public frmAddUpdateBookings()
        {
            InitializeComponent();
            Mode = EnMode.Add;
        }

        public frmAddUpdateBookings(int BookingID)
        {
            InitializeComponent();
            _BookingID = BookingID;
            Mode = EnMode.Update;
        }


        private void LoadDataInfo()
        {
            _Booking = ClsBooking.GetBookingByID(_BookingID);

            if(_Booking != null)
            {
                txtBookingID.Text = _Booking.BookingID.ToString();
                txtCustomerID.Text = _Booking.CustomerID.ToString();
                txtVehicleID.Text = _Booking.VehicleID.ToString();
                txtDropOff.Text = _Booking.DropOffLocation;
                txtPickUp.Text = _Booking.PickUpLocation;
                txtRentalDays.Text = _Booking.InitialRentalDays.ToString();
                txtRentalPricePerDay.Text = _Booking.RentalPricePerDay.ToString();
                txtTotalDueAmount.Text = _Booking.InitialTotalDueAmount.ToString();
                dtpStartDate.Value = _Booking.StartDate;
                dtpEndDate.Value = _Booking.EndDate;
            }

        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _Booking = new ClsBooking();

            _Booking.CustomerID = int.Parse(txtCustomerID.Text);
            _Booking.VehicleID = int.Parse(txtVehicleID.Text);
            _Booking.StartDate = dtpStartDate.Value;
            _Booking.EndDate = dtpEndDate.Value;
            _Booking.PickUpLocation = txtPickUp.Text;
            _Booking.DropOffLocation = txtDropOff.Text;
            _Booking.InitialRentalDays = Convert.ToInt32(txtRentalDays.Text);
            _Booking.RentalPricePerDay = decimal.Parse(txtRentalPricePerDay.Text);
            _Booking.InitialTotalDueAmount = decimal.Parse(txtTotalDueAmount.Text);
            _Booking.InitialCheckNotes = txtCheckNotes.Text;


            if (_Booking.Save())
            {
                MessageBox.Show("Add Booking Successfuly with Booking ID :"+_Booking.BookingID.ToString(), "Success ", MessageBoxButtons.OK);
                lbBookingD.Text = _Booking.BookingID.ToString();

                

                tcBooking.SelectedTab = tpTransactionPage;
                _Vehicle = ClsVehicles.FindVehicleByID(int.Parse(txtVehicleID.Text));
                if (_Vehicle != null)

                {
                    _Vehicle.IsAvailable = false;
                    if (!_Vehicle.Save())
                    {
                        return;
                    }
                }
                txtBookingID.Text = _Booking.BookingID.ToString();

                return;

            }
            else
            {
                MessageBox.Show("Error in Added Boooking ID", "Errors", MessageBoxButtons.OK);
            }
        }

        private void frmAddUpdateBookings_Load(object sender, EventArgs e)
        {

            if (Mode == EnMode.Update)
            {
                LoadDataInfo();
                return;
            }


            dtpStartDate.MinDate = DateTime.Today;
            dtpStartDate.Value = dtpStartDate.MinDate;

            dtpEndDate.MinDate = DateTime.Today;
            dtpEndDate.Value = dtpEndDate.MinDate;
            
        }

        private void txtCustomerID_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCustomerID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCustomerID, "This Faild is Requried!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCustomerID, null);
            }


          //  ClsCustomer customer = ClsCustomer.GetCustomerByID(int.Parse(txtCustomerID.Text));

            if(!ClsCustomer.CheckIsCustomerExists(int.Parse(txtCustomerID.Text)))
            {
                MessageBox.Show("There is no Customer With ID : " + txtCustomerID.Text, " Invaild", MessageBoxButtons.OK);

                e.Cancel = true;
                errorProvider1.SetError(txtCustomerID, "There is no Customer With ID : " + txtCustomerID.Text);

            }
            else
            {
                errorProvider1.SetError(txtCustomerID, null);
            }

        }

        private void txtVehicleID_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txtVehicleID.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtVehicleID, "This Faild Is Requried");
                return;
            }
            else
            {
                errorProvider1.SetError(txtVehicleID, null);
            }


            if(!ClsVehicles.CheckVehicleExists(int.Parse(txtVehicleID.Text.Trim())))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVehicleID, " There is no Vehicle With ID: " + txtVehicleID.Text);
                return;
            }
            else
            {
                errorProvider1.SetError(txtVehicleID, null);
            }

            if(!ClsVehicles.IsVehicleAvialable(int.Parse(txtVehicleID.Text.Trim())))
            {
                e.Cancel = true;
                MessageBox.Show("Vehicle Is Not Vaialable Right Now!!", "Not Avaialable", MessageBoxButtons.OK);
            }

           
        }

     

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
           DateTime dateTime1 = dtpStartDate.Value;
            DateTime dateTime2 = dtpEndDate.Value;



            TimeSpan Diff = dateTime2 - dateTime1;

           
            txtRentalDays.Text = Diff.Days.ToString() ;




        }

       

        private void txtRentalPricePerDay_TextChanged(object sender, EventArgs e)
        { 

            if(string.IsNullOrEmpty(txtRentalPricePerDay.Text))
            {
                return;
            }

            decimal Price = decimal.Parse(txtRentalPricePerDay.Text);
            int Days = int.Parse(txtRentalDays.Text);
            decimal total = Price * Days;
            txtTotalDueAmount.Text = total.ToString();


        }

        private void txtRentalPricePerDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( ! char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _Transaction = new ClsTransaction();
            _Transaction.BookingID = int.Parse(txtBookingID.Text);
            _Transaction.PaymentDetails = txtPaymentDetails.Text;
            _Transaction.PaidInitialTotalDueAmount = decimal.Parse(txtPaidInitinalTotalAmount.Text);
            _Transaction.TransactionDate = dtpTransactionDate.Value;
            if(_Transaction.Save())
            {
                MessageBox.Show("Add Transaction Successfuly with Booking ID :" +_Transaction.TransactionID.ToString(), "Success ", MessageBoxButtons.OK);
                return;

            }
            else
            {
                MessageBox.Show("Failed in Add Transaction ", " Error", MessageBoxButtons.OK);
            }
        }
    }
}
