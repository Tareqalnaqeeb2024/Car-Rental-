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
using CarRental.Customers;
using CarRental.Booking;
using CarRental.VehicelsReturn;

namespace CarRental.Vehicles
{
    public partial class frmVehicles : Form
    {
        public frmVehicles()
        {
            InitializeComponent();
        }

        public int _VehicleID = 0;
        public ClsVehicles _Vehicle ;
        private void btnFind_Click(object sender, EventArgs e)
        {
          _VehicleID = Convert.ToInt32(txtSereach.Text);

            _Vehicle = ClsVehicles.FindVehicleByID(_VehicleID);

            if (_Vehicle != null)
            {
                txtAddress.Text = _Vehicle.Model;
                txtEmail.Text = _Vehicle.Make;
            }
            //DataTable dataTable = ClsVehicles.FindVehicleByID(_VehicleID);

            //if (dataTable.Rows.Count >0 )
            //{
            //    MessageBox.Show($"Yes  , Vehicle Exists    ");


            //    DataRow dataRow = dataTable.Rows[0];



            //    txtCustomerID.Text = dataRow["Make"].ToString();
            //    txtDriverLicense.Text = dataRow["Model"].ToString();
            //    txtEmail.Text = dataRow["Mileage"].ToString();


            //}

            else
            {
                MessageBox.Show("No , Vehicle Is Not Exist");
            }
        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.ShowDialog();
        }

        private void btnShowListVehicles_Click(object sender, EventArgs e)
        {
            frmListVehicles frm = new frmListVehicles();
            frm.ShowDialog();
        }

        private void frmVehicles_Load(object sender, EventArgs e)
        {

        }

        private void btnFindVehicleInfo_Click(object sender, EventArgs e)
        {
            frmShowVehicleCardsInfo frm = new frmShowVehicleCardsInfo();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmShowListCustomers frm = new frmShowListCustomers();
            frm.ShowDialog();
        }

        private void btnShowListBookings_Click(object sender, EventArgs e)
        {
            frmShowBookingList frm = new frmShowBookingList();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddUpdateBookings frm = new frmAddUpdateBookings();
            frm.ShowDialog();
        }

        private void btnAddNewReturnVehicle_Click(object sender, EventArgs e)
        {
            frmAddUpdateReturns frm = new frmAddUpdateReturns();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmVehicleReturnList frm = new frmVehicleReturnList();
            frm.ShowDialog();
        }
    }
}
