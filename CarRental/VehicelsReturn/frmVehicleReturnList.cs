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
namespace CarRental.VehicelsReturn
{
    public partial class frmVehicleReturnList : Form
    {

        public DataTable _dtAllVehicleReturn = ClsVehicleReturn.GetAllVehiclesReturns();
        public frmVehicleReturnList()
        {
            InitializeComponent();
        }

        private void frmVehicleReturnList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            dgvVehiclesReturnList.DataSource = _dtAllVehicleReturn;

            if(dgvVehiclesReturnList.Rows.Count > 0)
            {
                






                dgvVehiclesReturnList.Columns[0].HeaderText = "Return ID";
                dgvVehiclesReturnList.Columns[0].Width =80 ;

                dgvVehiclesReturnList.Columns[1].HeaderText = "Booking ID";
                dgvVehiclesReturnList.Columns[1].Width = 80;

                dgvVehiclesReturnList.Columns[2].HeaderText = "Transaction ID";
                dgvVehiclesReturnList.Columns[2].Width = 80;

                dgvVehiclesReturnList.Columns[3].HeaderText = "Actual Return Date";
                dgvVehiclesReturnList.Columns[3].Width = 100;

                dgvVehiclesReturnList.Columns[4].HeaderText = "Actual Rental Days";
                dgvVehiclesReturnList.Columns[4].Width =100 ;

                dgvVehiclesReturnList.Columns[5].HeaderText = "Mileage";
                dgvVehiclesReturnList.Columns[5].Width = 100;

                dgvVehiclesReturnList.Columns[6].HeaderText = "Consumed  Mileage ";
                dgvVehiclesReturnList.Columns[6].Width = 120;

                dgvVehiclesReturnList.Columns[7].HeaderText = "Final Check Notes";
                dgvVehiclesReturnList.Columns[7].Width = 120;

                dgvVehiclesReturnList.Columns[8].HeaderText = "Addtional Charges";
                dgvVehiclesReturnList.Columns[8].Width = 120;


                dgvVehiclesReturnList.Columns[9].HeaderText = "Actual Total Due Amount";
                dgvVehiclesReturnList.Columns[9].Width = 100;



            }

            lbTotalVehiclesReturn.Text = dgvVehiclesReturnList.Rows.Count.ToString();
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateReturns frm = new frmAddUpdateReturns();
            frm.ShowDialog();

            frmVehicleReturnList_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ReturnID = (int)dgvVehiclesReturnList.CurrentRow.Cells[2].Value;
            frmAddUpdateReturns frm = new frmAddUpdateReturns(ReturnID);
            frm.ShowDialog();
        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Return ID":
                    ColumnFilter = "ReturnID";
                    break;
                case "Transaction ID":
                    ColumnFilter = "TransactionID";
                    break;
                case "Booking ID":
                    ColumnFilter = "BookingID";
                    break;
                case "Actual Rental Days":
                    ColumnFilter = "ActualRentalDays";
                    break;
                case "Mileage":
                    ColumnFilter = "Mileage";
                    break;
                case "Consumed Mileage":
                    ColumnFilter = "ConsumedMileage";
                    break;
                case "Final Check Notes":
                    ColumnFilter = "FinalCheckNotes";
                    break;
                case "Addtional Charges":
                    ColumnFilter = "AddtionalCharges";
                    break;
                case "Actual Total Due Amount":
                    ColumnFilter = "ActualTotalDueAmount";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if(txtFilterTextValue.Text.Trim() == "" || ColumnFilter ==null)
            {

                _dtAllVehicleReturn.DefaultView.RowFilter = "";
                lbTotalVehiclesReturn.Text = dgvVehiclesReturnList.Rows.Count.ToString();
                return;
            }

            if (ColumnFilter == "ReturnID" || ColumnFilter == "ActualRentalDays" || ColumnFilter == "Mileage" || ColumnFilter == "ConsumedMileage" 
                || ColumnFilter == "ActualTotalDueAmount" || ColumnFilter == "TransactionID" || ColumnFilter == "BookingID")

                _dtAllVehicleReturn.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, txtFilterTextValue.Text.Trim());
            else
                _dtAllVehicleReturn.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnFilter, txtFilterTextValue.Text.Trim());

                lbTotalVehiclesReturn.Text = dgvVehiclesReturnList.Rows.Count.ToString();



        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(cbFilterBy.Text == "Return ID" || cbFilterBy.Text == "Actual Rental Days" || cbFilterBy.Text == "Mileage" || cbFilterBy.Text == "Consumed Mileage" || cbFilterBy.Text == "Actual Total Due Amount"
                || cbFilterBy.Text == "TransactionID"  || cbFilterBy.Text =="Booking ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterTextValue.Enabled = cbFilterBy.SelectedIndex != 0;

            if(cbFilterBy.SelectedIndex != 0)
            {
                txtFilterTextValue.Focus();
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmAddUpdateReturns frm = new frmAddUpdateReturns();
            frm.ShowDialog();
            frmVehicleReturnList_Load(null, null);
        }
    }
}
