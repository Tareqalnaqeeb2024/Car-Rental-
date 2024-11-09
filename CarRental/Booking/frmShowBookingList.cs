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
    public partial class frmShowBookingList : Form
    {
        public static DataTable dtAllBookings = ClsBooking.GetAllBookings();
        public DataTable dtBookingsList = dtAllBookings.DefaultView.ToTable(false, "BookingID", "VehicleID", "CustomerID", "StartDate", "EndDate", "PickUpLocation", "DropOffLocation",
            "RentalPricePerDay", "InitialCheckNotes", "InitialTotalDueAmount", "InitialRentalDays");
        public frmShowBookingList()
        {
            InitializeComponent();
        }

        private void frmShowBookingList_Load(object sender, EventArgs e)
        {
            dgvBookingList.DataSource = dtBookingsList;

            cbFilterBy.SelectedIndex = 0;

            if(dgvBookingList.Rows.Count > 0)
            {
                dgvBookingList.Columns[0].HeaderText = "Booking ID";
                dgvBookingList.Columns[0].Width = 70 ;

                dgvBookingList.Columns[1].HeaderText = "Vehicle ID";
                dgvBookingList.Columns[1].Width = 70;

                dgvBookingList.Columns[2].HeaderText = "Customer ID";
                dgvBookingList.Columns[2].Width = 70;

                dgvBookingList.Columns[3].HeaderText = "Start Date ";
                dgvBookingList.Columns[3].Width = 100;

                dgvBookingList.Columns[4].HeaderText = "End Date ";
                dgvBookingList.Columns[4].Width = 100;

                dgvBookingList.Columns[5].HeaderText = "Pick Up";
                dgvBookingList.Columns[5].Width = 110;

                dgvBookingList.Columns[6].HeaderText = "Drop Off";
                dgvBookingList.Columns[6].Width = 110;

                dgvBookingList.Columns[7].HeaderText = "Price Per Day $ ";
                dgvBookingList.Columns[7].Width = 70;

                dgvBookingList.Columns[8].HeaderText = "Initial Check Notes ";
                dgvBookingList.Columns[8].Width = 100;

                dgvBookingList.Columns[9].HeaderText = "Initial Total Due Amount";
                dgvBookingList.Columns[9].Width = 100;

                dgvBookingList.Columns[10].HeaderText = "Initial Total  Days";
                dgvBookingList.Columns[10].Width = 70;
            }
            lbTotalBookings.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBookings frm = new frmAddUpdateBookings();
            frm.ShowDialog();
        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Vehicle ID":
                    FilterColumn = "VehicleID";
                    break;
                case "Customer ID":
                    FilterColumn = "CustomerID";
                    break;
                case "Booking ID":
                    FilterColumn = "BookingID";
                    break;
                case "Start Of Date":
                    FilterColumn = "StartDate";
                    break;
                case "End Of Date":
                    FilterColumn = "EndDate";
                    break;
                case "Pick Up  Location":
                    FilterColumn = "PickUpLocation";
                    break;
                case "Drop Off Location":
                    FilterColumn = "DropOffLocation";
                    break;
                case "Price Per Day":
                    FilterColumn = "RentalPricePerDay";
                    break;
                
                default:
                    FilterColumn = "None";
                    break;

            }

            if(txtFilterTextValue.Text.Trim() == "" || FilterColumn == "")
            {
                dtBookingsList.DefaultView.RowFilter = "";
                lbTotalBookings.Text = dgvBookingList.Rows.Count.ToString();
                return;
            }
            //if(FilterColumn == "StartDate" || FilterColumn == "EndDate")
            //{
            //   dtBookingsList.DefaultView.RowFilter = string.Format("[{0}] = '{1}%'", FilterColumn, txtFilterTextValue.Text.Trim());
            //}

            if (FilterColumn == "BookingID" || FilterColumn == "VehicleID" || FilterColumn == "CustomerID" || FilterColumn == "RentalPricePerDay")
                dtBookingsList.DefaultView.RowFilter = string.Format("[{0}] = {1}",  FilterColumn , txtFilterTextValue.Text.Trim());
            else
                dtBookingsList.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn ,txtFilterTextValue.Text.Trim());
            
                

            lbTotalBookings.Text = dgvBookingList.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterTextValue.Enabled = cbFilterBy.Text != "None";

            if (cbFilterBy.Text != "None")
                txtFilterTextValue.Focus();
        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "Customer ID" || cbFilterBy.Text == "Vehicle ID" || cbFilterBy.Text == "Booking ID" || cbFilterBy.Text == "Price Per Day")
            {
                e.Handled =( !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
               }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID =(int) dgvBookingList.CurrentRow.Cells[0].Value;
            frmAddUpdateBookings frm = new frmAddUpdateBookings(BookingID);
            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = (int)dgvBookingList.CurrentRow.Cells[0].Value;

            frmShowBookingInfo frm = new frmShowBookingInfo(BookingID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = (int)dgvBookingList.CurrentRow.Cells[0].Value;

            if(MessageBox.Show("Are you sure To Delete This Booking with ID["+BookingID+"]?","Confrim",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if(ClsBooking.DeleteBookingByID(BookingID) )
                {
                    MessageBox.Show("Deleted Successfuly", "Success");
                    frmShowBookingList_Load(null, null);
                    this.Refresh();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Deleted Failed", "Failure");

            }

        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmAddUpdateBookings frm = new frmAddUpdateBookings();
            frm.ShowDialog();
            this.Refresh();
       }
    }
}
