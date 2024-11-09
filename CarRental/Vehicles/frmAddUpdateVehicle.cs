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


namespace CarRental.Vehicles
{
    public partial class frmAddUpdateVehicle : Form
    {
        public delegate void DataBackEventHandler(object sender, int VehicelID);
        public  event DataBackEventHandler SendDataBack;

        public enum EnMode { Add = 1 ,Update =2};
        public EnMode Mode = EnMode.Add;
        public ClsVehicles _Vehicles;
        public int _VehicleID ;
        public int _PlateID;
        public ClsPlateDetails _PlateDetails;
        public DataTable AllVehicles = ClsVehicles.GetAllVehicles();

        public frmAddUpdateVehicle()
        {
            InitializeComponent();
            Mode = EnMode.Add;
            _Vehicles = new ClsVehicles();
            _PlateDetails = new ClsPlateDetails();
        }




        public frmAddUpdateVehicle( int VehicleID)
        {

            InitializeComponent();
            _VehicleID = VehicleID;

            Mode = EnMode.Update;
        }
        private void frmAddUpdateVehicle_Load(object sender, EventArgs e)
        {

            if(Mode == EnMode.Add)
            {
                lbTitle.Text = " Add New Vehicle";
            }
            _ResetDefalutValues();

            if (Mode == EnMode.Update)
                lbTitle.Text = " Update Vehicel";
            LoadVehicleData();

        }

        private void _ResetDefalutValues()
        {
            _GetAllFulesTypesNames();
            txtMake.Text = "";
            txtModel.Text = "";
            txtMadeYear.Text = "";
            txtMileage.Text = "";
            txtPricePerDay.Text = "";
            txtPlateNumber.Text = "";
            txtCityNumber.Text = "";
            cmbPlateType.Text = "";
            lbVehicleID.Text = "";
        }

        private void _GetAllFulesTypesNames()
        {

            DataTable FulesName = ClsFulesTypes.GetAllFulesTypesName();

            foreach (DataRow row in FulesName.Rows)
            {
                cmbFulesNames.Items.Add(row["FuleTypeName"]);
            }

        }



        private void btnAddNew_Click(object sender, EventArgs e)
        {

            _PlateDetails.PlateNumber = int.Parse(txtPlateNumber.Text);
            _PlateDetails.PlateType = cmbPlateType.Text;
            _PlateDetails.CityNumber = int.Parse(txtCityNumber.Text);

            if (!_PlateDetails.Save())
            {

                MessageBox.Show("Error on Plating Number");
                return;

            }

            _PlateID = _PlateDetails.PlateID;
            _Vehicles.PlateNumberID = _PlateID;
            _Vehicles.Make = txtMake.Text;
            _Vehicles.Model = txtModel.Text;
            _Vehicles.MadeYear = int.Parse(txtMadeYear.Text);
            _Vehicles.Mileage = int.Parse(txtMileage.Text);
            _Vehicles.RentalPricePerDay = decimal.Parse(txtPricePerDay.Text);
            if (_Vehicles.ImagePath != null)
            {
                _Vehicles.ImagePath = pbVehicleImage.ImageLocation;
            }
            else
            {
                _Vehicles.ImagePath = "";
            }
            if (chkNo.Checked)
            {
                _Vehicles.IsAvailable = false;
            }
            else
            {
                _Vehicles.IsAvailable = true;
            }

            int FuleTypeID = cmbFulesNames.SelectedIndex;


            _Vehicles.FuleTypeID = FuleTypeID;

            if (_Vehicles.Save())
            {
                MessageBox.Show("Data Saved Successfuly", "Success");
                _VehicleID = _Vehicles.VehicleID;
                lbVehicleID.Text = _Vehicles.VehicleID.ToString();
                _Vehicles.IsAvailable = false;
                Mode = EnMode.Update;
                SendDataBack?.Invoke(this, _VehicleID);

                return;

            }

            else
            {
                MessageBox.Show(" Errors , In Add New Vehicle ");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvVehiclesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void LoadVehicleData()
        {
        
            _Vehicles = ClsVehicles.FindVehicleByID(_VehicleID);


            if (_Vehicles != null)
            {

                txtMake.Text = _Vehicles.Make;
                txtModel.Text = _Vehicles.Model;
                txtMadeYear.Text = _Vehicles.MadeYear.ToString();
                txtMileage.Text = _Vehicles.Mileage.ToString();
                txtPricePerDay.Text = _Vehicles.RentalPricePerDay.ToString();
                _PlateID = _Vehicles.PlateNumberID;
                _PlateDetails = ClsPlateDetails.GetPlatDetailsByID(_PlateID);
                if (_PlateDetails != null)
                txtPlateNumber.Text = _PlateDetails.PlateNumber.ToString();
                txtCityNumber.Text = _PlateDetails.CityNumber.ToString();
                cmbPlateType.Text = _PlateDetails.PlateType;
                lbVehicleID.Text = _Vehicles.VehicleID.ToString();
                if (_Vehicles.ImagePath != "" )
                    pbVehicleImage.Load(_Vehicles.ImagePath);
                else
                    pbVehicleImage.Image = Properties.Resources.Cars_48;
                int FuleID = _Vehicles.FuleTypeID;
                cmbFulesNames.Text = ClsFulesTypes.GetFuleTypeByID(_Vehicles.FuleTypeID).FuleTypeName;
                if(_Vehicles.IsAvailable)
                
                    chkYes.Checked = true;
               else

                    chkNo.Checked = true;
  
            }
           
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Images Files  |*jpg ;*.jpeg ;*.Png";

            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog () == DialogResult.OK )
            {
                pbVehicleImage.Load(openFileDialog1.FileName);
            }

        }
    }
}
