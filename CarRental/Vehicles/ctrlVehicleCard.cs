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
using System.IO;
using CarRental.Properties;


namespace CarRental.Vehicles
{
    public partial class ctrlVehicleCard : UserControl
    {
        private int _VehicleID;
        private ClsVehicles _Vehicle;

        
        public ctrlVehicleCard()
        {
          
            InitializeComponent();
        }


        private void ctrlVehicleCard_Load(object sender, EventArgs e)
        {
            
            
           
             

  
        }


        public void LoadVehicleInfo(int VehicleID)
        {

            _Vehicle = ClsVehicles.FindVehicleByID(VehicleID);
            if (_Vehicle == null)
            {
                MessageBox.Show("Vehicle Is Not Exists");

            }
            else
            {
                lbVehicleID1.Text = _Vehicle.VehicleID.ToString();
                lbMake.Text = _Vehicle.Make;
                lbModel.Text = _Vehicle.Model;
                lbMadeYear.Text = _Vehicle.MadeYear.ToString();
                lbMileage.Text = _Vehicle.Mileage.ToString();
                int PlateID = _Vehicle.PlateNumberID;
                lbPlateType.Text = ClsPlateDetails.GetPlatDetailsByID(PlateID).PlateType;
                lbPlateNumber.Text = ClsPlateDetails.GetPlatDetailsByID(PlateID).PlateNumber.ToString();
                lbCityNumber.Text = ClsPlateDetails.GetPlatDetailsByID(PlateID).CityNumber.ToString();
                lbPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString();
                lbIsAvailable.Text = _Vehicle.IsAvailable ? "Yes" : "No";

                LoadVehicleImage();
            }
            
        }

        private void LoadVehicleImage()
        {
            string FileName = _Vehicle.ImagePath;

            if(FileName != "")
            {
                if(File.Exists(FileName))
                {
                    pbVehicle.ImageLocation = FileName;
                }else
                {
                    MessageBox.Show("we Can not Find The Image Path ");
                }
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
