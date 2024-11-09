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
    public partial class ctrlBookingCard : UserControl
    {
        public ClsBooking _Booking;
        public int _BookingID;

        public int BookingID
        {
            get { return _BookingID; }
        }
        public ctrlBookingCard()
        {
            InitializeComponent();
        }

        private void ctrlBookingCard_Load(object sender, EventArgs e)
        {
            LoadBookingData(_BookingID);
        }

        public void LoadBookingData(int BookingID)
        {
            _Booking = ClsBooking.GetBookingByID(BookingID);

            if(_Booking != null)
            {
                lbBookingD.Text = _Booking.BookingID.ToString();
                lbCustomerID.Text = _Booking.CustomerID.ToString();
                 lbVehiclID.Text = _Booking.VehicleID.ToString();
                lbDropOff.Text  = _Booking.DropOffLocation;
                lbPickUp.Text = _Booking.PickUpLocation;
                lbRentalDays.Text = _Booking.InitialRentalDays.ToString();
                lbPricePerDay.Text = _Booking.RentalPricePerDay.ToString();
                lbInitialTotalDurAmount.Text = _Booking.InitialTotalDueAmount.ToString();
                lbStartDate.Text = _Booking.StartDate.ToString();
                lbEndDate.Text = _Booking.EndDate.ToString();
            }
        }
    }
}
