using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmShowVehicleCardsInfo : Form
    {
        private int _VehicleID = -1;
        public frmShowVehicleCardsInfo(int VehicleID)
        {
            _VehicleID = VehicleID;
            InitializeComponent();
        }
        public frmShowVehicleCardsInfo()
        {
           
            InitializeComponent();
        }

        private void frmShowVehicleCardsInfo_Load(object sender, EventArgs e)
        {
            ctrlVehicleCard1.LoadVehicleInfo(_VehicleID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
          
        }
    }
}
