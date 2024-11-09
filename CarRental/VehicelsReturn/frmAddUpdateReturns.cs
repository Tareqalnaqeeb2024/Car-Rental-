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


namespace CarRental.VehicelsReturn
{
    public partial class frmAddUpdateReturns : Form
    {
        public enum EnMode { Add =1 , Update =2};
        public EnMode Mode = EnMode.Add;
        public ClsVehicleReturn _Return;
        public ClsTransaction _Transaction;
        public ClsVehicles _Vehicle;
        public int _VehicleID;
        public int _TransactionID;
        public ClsBooking _Booking;
        public int _BookingID;
        public int _ReturnID;
        int InitinalRentalDays;
        decimal Diff;
        decimal TotalRemin;
        decimal TotalReFounded;
        public frmAddUpdateReturns()
        {
            InitializeComponent();
            Mode = EnMode.Add;
        }

        public frmAddUpdateReturns( int TransactionID)
        {
            InitializeComponent();
            Mode = EnMode.Update;
            _TransactionID = TransactionID;
        }

        public void LoadReturData()
        {

            _Transaction = ClsTransaction.GetTransactionByID(_TransactionID);
            if (_Transaction != null)
            {
                _Return = ClsVehicleReturn.FindVehicleReturnByID(_Transaction.ReturnID);

                txtTransactionID.Text = _TransactionID.ToString();
                lbreturnD.Text = _Return.ReturnID.ToString();
                txtActualRentalDays.Text = _Return.ActualRentalDays.ToString();
                txtActualTotalAmount.Text = _Return.ActualTotalDueAmount.ToString();
                txtAddtionalCharges.Text = _Return.AddtionalCharges.ToString();
                txtConsumedMileage.Text = _Return.ConsumedMileage.ToString();
                dtpActualReturnDate.Value = _Return.ActualReturnDate;
                txtMileage.Text = _Return.Mileage.ToString();
                txtFinalCheckNotes.Text = _Return.FinalCheckNotes;
            }
        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {



            _Return = ClsVehicleReturn.FindVehicleReturnByID(_ReturnID);

            if(_Return != null)
            {
                LoadReturData();
                return;
            }
            _Return = new ClsVehicleReturn();

            _Return.ActualReturnDate = dtpActualReturnDate.Value;
            _Return.ActualRentalDays = int.Parse(txtActualRentalDays.Text);
            _Return.Mileage = int.Parse(txtMileage.Text);
            _Return.ConsumedMileage = int.Parse(txtMileage.Text);
            _Return.FinalCheckNotes = txtFinalCheckNotes.Text;
            _Return.ActualTotalDueAmount = decimal.Parse(txtActualTotalAmount.Text)  ;
            _Return.AddtionalCharges = txtAddtionalCharges.Text;

            if(_Return.Save())
            {
                MessageBox.Show("Data Saved Successfuly", "Success", MessageBoxButtons.OK);
                lbreturnD.Text = _Return.ReturnID.ToString();


                _Transaction = ClsTransaction.GetTransactionByID(int.Parse(txtTransactionID.Text));

                if (_Transaction != null )
                {
                    _TransactionID = _Transaction.TransactionID;
                  Diff= _Return.ActualTotalDueAmount - _Transaction.PaidInitialTotalDueAmount;
                   
                   
                        if( Diff ==0 )
                    {
                        TotalRemin = 0;
                        TotalReFounded = 0;
                    }
                        else if(Diff >0 )
                    {
                        TotalRemin = Diff;
                    }
                        else
                    {
                        TotalReFounded = Diff * -1;
                    }

                    _BookingID = _Transaction.BookingID;
                    _VehicleID = _Booking.VehicleID;
                    _Transaction.ReturnID = _Return.ReturnID;
                    _Transaction.ActualTotalDueAmount = _Return.ActualTotalDueAmount;
                    _Transaction.UpdatedTransactionDate = DateTime.Today;
                    _Transaction.TotalRemaining = TotalRemin;
                    _Transaction.TotalRefunedAmount = TotalReFounded;

                    _Vehicle = ClsVehicles.FindVehicleByID(_VehicleID);
                        if(_Vehicle != null)
                    {
                        _Vehicle.IsAvailable = true;

                        if(!_Vehicle.Save())
                        {
                            return;
                        }
                    }



                 
                

                }



            }






        }

        private void dtpActualReturnDate_ValueChanged(object sender, EventArgs e)
        {


            // int BookingID = _Transaction.BookingID;

            if (Mode == EnMode.Update)
            {
                return;
            }
            _Transaction = ClsTransaction.GetTransactionByID(int.Parse(txtTransactionID.Text));


            if(_Transaction == null)
            {
                MessageBox.Show("No Found Trasaction With this ID :["+ txtTransactionID.Text+"]","Falied");
                return;
            }

            _TransactionID = _Transaction.TransactionID;
            _BookingID = _Transaction.BookingID;
            _Booking = ClsBooking.GetBookingByID(_BookingID);

            if (_Booking != null)
            {
                // InitinalRentalDays = _Booking.InitialRentalDays;
            }
            else
            {
                MessageBox.Show("Error in Get Booking Class");
            }


            TimeSpan timeSpan =  dtpActualReturnDate.Value - _Booking.EndDate;


            int TotalActualDays = timeSpan.Days + _Booking.InitialRentalDays;
            // txtActualRentalDays.Text = Math.Abs(timeSpan.Days + _Booking.InitialRentalDays).ToString();
            txtActualRentalDays.Text = TotalActualDays.ToString();


           // decimal ActualDueAmount = Math.Abs( timeSpan.Days) * _Booking.RentalPricePerDay;
            decimal ActualDueAmount = TotalActualDays * _Booking.RentalPricePerDay;


            txtActualTotalAmount.Text = ActualDueAmount.ToString();


        }

        private void frmAddUpdateReturns_Load(object sender, EventArgs e)
        {
            if (Mode == EnMode.Update)
            {
                LoadReturData();

            }
        }

        private void txtTransactionID_MouseUp(object sender, MouseEventArgs e)
        {
            //_Transaction = ClsTransaction.GetTransactionByID(int.Parse(txtTransactionID.Text));

        }

      

        private void txtMileage_KeyUp(object sender, KeyEventArgs e)
        {
            int VehiceID = _Booking.VehicleID;

            if(txtMileage.Text == "")
            {
                return;
            }

            ClsVehicles clsVehicles = ClsVehicles.FindVehicleByID(VehiceID);

            if (clsVehicles != null)
            {

                int ConsumedMileage = Convert.ToInt32(txtMileage.Text) - clsVehicles.Mileage;

                txtConsumedMileage.Text = ConsumedMileage.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
