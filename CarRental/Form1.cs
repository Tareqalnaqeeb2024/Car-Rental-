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
using CarRental.Booking;
using CarRental.Customers;
using CarRental.Vehicles;
using CarRental.VehicelsReturn;
using CarRental.Transactions;

namespace CarRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {

            frmShowListCustomers frm = new frmShowListCustomers();
            frm.ShowDialog();
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            frmListVehicles frm = new frmListVehicles();
            frm.ShowDialog();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            frmShowBookingList frm = new frmShowBookingList();
            frm.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            frmTransactionList frm = new frmTransactionList();
            frm.ShowDialog();
        }

        private void btnReturnScreen_Click(object sender, EventArgs e)
        {
            frmVehicleReturnList frm = new frmVehicleReturnList();
            frm.ShowDialog();
        }
    }
}
