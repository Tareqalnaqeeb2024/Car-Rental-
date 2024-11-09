using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmShowBookingInfo : Form
    {
        public int _BookingID;
        public frmShowBookingInfo(int BookingID)
        {
            InitializeComponent();
            _BookingID = BookingID; 
        }

        private void frmShowBookingInfo_Load(object sender, EventArgs e)
        {
            ctrlBookingCard1.LoadBookingData(_BookingID);
        }
    }
}
