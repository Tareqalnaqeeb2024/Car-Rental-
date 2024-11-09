using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.Vehicles;

namespace CarRental.Vehicles
{
    public partial class ctrlFilterVehicle : UserControl
    {
        public ctrlFilterVehicle()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if(txtSearch.Text == string.Empty.Trim() || txtSearch.Text == "")
            {
                MessageBox.Show("Please inter VehicleID", "Invaild Data", MessageBoxButtons.OK);
                return;
            }

            else
            {
                int VehicleID = int.Parse(txtSearch.Text);

                ctrlVehicleCard1.LoadVehicleInfo(VehicleID);
            }
        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {

            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.SendDataBack += SendDataBack2;
            frm.ShowDialog();
        }

        private void SendDataBack2(object sender, int VehicleID)
        {
              
            ctrlVehicleCard1.LoadVehicleInfo(VehicleID);

        }

        private void ctrlFilterVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
