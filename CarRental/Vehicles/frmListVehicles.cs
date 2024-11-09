using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataBusiness;



namespace CarRental.Vehicles
{
    public partial class frmListVehicles : Form
    {
        public frmListVehicles()
        {
            InitializeComponent();
        }

        public static DataTable dtAllVechicles = ClsVehicles.GetAllVehicles();
        public DataTable _dtVechiles = dtAllVechicles.DefaultView.ToTable(false, "VehicleID", "Make", "Model", "MadeYear", "Mileage", "RentalPricePerDay",
           "IsAvailable", "FuleTypeName", "PlateNumber");

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form frm = new frmAddUpdateVehicle((int)dgvVehiclesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void frmListVehicles_Load(object sender, EventArgs e)
        {
            
            dgvVehiclesList.DataSource = _dtVechiles;
            lbTotalVehicles.Text = "#"+ dgvVehiclesList.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvVehiclesList.Rows.Count > 0)
            {
                dgvVehiclesList.Columns[0].HeaderText = "Vehicle ID";
                dgvVehiclesList.Columns[0].Width = 110;

                dgvVehiclesList.Columns[1].HeaderText = "Make";
                dgvVehiclesList.Columns[1].Width = 100;

                dgvVehiclesList.Columns[2].HeaderText = "Model";
                dgvVehiclesList.Columns[2].Width = 100;

                dgvVehiclesList.Columns[3].HeaderText = "Made Year";
                dgvVehiclesList.Columns[3].Width = 100;

                dgvVehiclesList.Columns[4].HeaderText = "Mileage";
                dgvVehiclesList.Columns[4].Width = 120;

                dgvVehiclesList.Columns[5].HeaderText = "Rental Price Per Day";
                dgvVehiclesList.Columns[5].Width = 100;

                dgvVehiclesList.Columns[6].HeaderText = "Is Available";
                dgvVehiclesList.Columns[6].Width = 100;

                dgvVehiclesList.Columns[7].HeaderText = "Fule Type Name";
                dgvVehiclesList.Columns[7].Width = 200;

                dgvVehiclesList.Columns[8].HeaderText = "Plate Number";
                dgvVehiclesList.Columns[8].Width = 120;

                //dgvVehiclesList.Columns[9].HeaderText = "Vehicle ID";
                //dgvVehiclesList.Columns[9].Width = 80;
            }

        }

        private void dgvVehiclesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterTextValue.Visible = cbFilterBy.Text != "None";
           



        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Vehicle ID":

                    FilterColumn = "VehicleID";
                    break;
                case "Make":
                    FilterColumn = "Make";
                    break;

                case "Model":
                    FilterColumn = "Model";
                    break;
                case "Price":
                    FilterColumn = "RentalPricePerDay";
                    break;
                case "Plate Number":
                    FilterColumn = "PlateNumber";
                    break;
                case "Is Available":
                    FilterColumn = "IsAvailable";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }


            if (txtFilterTextValue.Text.Trim() == "" || FilterColumn == null )
            { 
                _dtVechiles.DefaultView.RowFilter = "";
                lbTotalVehicles.Text = dgvVehiclesList.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "VehicleID" || FilterColumn == "PlateNumber" || FilterColumn == "RentalPricePerDay")

                _dtVechiles.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterTextValue.Text.Trim());
            else
                _dtVechiles.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterTextValue.Text.Trim());

            lbTotalVehicles.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleCardsInfo frm = new frmShowVehicleCardsInfo((int)dgvVehiclesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.ShowDialog();

            frmListVehicles_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int VehicleID = (int)dgvVehiclesList.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Sure To Delete this Vehicle !!!","Delete Confrim",MessageBoxButtons.OKCancel )== DialogResult.OK)
            {
                if (ClsVehicles.DeleteVehicleByID(VehicleID) == true)
                {
                    MessageBox.Show("Deleted Successfuly ", "Sucessful",MessageBoxButtons.OK);
                    frmListVehicles_Load(null, null);
                    return;
                    
                }
                else
                {
                    MessageBox.Show("Errors in Delete", " Errors");
                }

            }

        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.ShowDialog();
            frmListVehicles_Load(null, null);
        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(cbFilterBy.Text == "Vehicle ID" || cbFilterBy.Text == "Plate Number" || cbFilterBy.Text == "Price")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
                



            }
        }
    }
}
