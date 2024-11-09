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

namespace CarRental.Customers
{
    public partial class frmShowListCustomers : Form
    {
        public static DataTable dtAllCustomers = ClsCustomer.GetAllCustomers();
        public DataTable _AllCustomers = dtAllCustomers.DefaultView.ToTable(false, "CustomerID", "Name", "NationalID", "Email", "Address", "Phone", "DriverLicense");
        public frmShowListCustomers()
        {
            InitializeComponent();
        }

        private void dgvCustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmShowListCustomers_Load(object sender, EventArgs e)
        {
            dgvCustomersList.DataSource = _AllCustomers;
            lbTotalCustomers.Text = "#" + dgvCustomersList.Rows.Count.ToString();

            if(dgvCustomersList.Rows.Count >0)
            {

                dgvCustomersList.Columns[0].HeaderText = "Customer ID";
                dgvCustomersList.Columns[0].Width = 100;

                dgvCustomersList.Columns[1].HeaderText = " Full Name ";
                dgvCustomersList.Columns[1].Width = 150;

                dgvCustomersList.Columns[2].HeaderText = "National ID";
                dgvCustomersList.Columns[2].Width = 100;

                dgvCustomersList.Columns[3].HeaderText = "Address";
                dgvCustomersList.Columns[3].Width = 150;

                dgvCustomersList.Columns[4].HeaderText = "Email ";
                dgvCustomersList.Columns[4].Width = 150;

                dgvCustomersList.Columns[5].HeaderText = "Phone ";
                dgvCustomersList.Columns[5].Width = 100;

                dgvCustomersList.Columns[6].HeaderText = "Driver Lincese";
                dgvCustomersList.Columns[6].Width = 100;

            }


        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomers frm = new frmAddUpdateCustomers();
            frm.ShowDialog();
            frmShowListCustomers_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Cus = (int)dgvCustomersList.CurrentRow.Cells[0].Value;
            frmAddUpdateCustomers frm = new frmAddUpdateCustomers(Cus);
            frm.ShowDialog();
            frmShowListCustomers_Load(null, null);

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomers frm = new frmAddUpdateCustomers();
            frm.ShowDialog();

            frmShowListCustomers_Load(null, null);
        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {

            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Customer ID":
                    ColumnFilter = "CustomerID";
                    break;
                case "Name":
                    ColumnFilter = "Name";
                    break;
                case "National ID":
                    ColumnFilter = "NationalID";
                    break;
                case "Address":
                    ColumnFilter = "Address";
                    break;
                case "Email":
                    ColumnFilter = "Email";
                    break;
                case "Phone":
                    ColumnFilter = "Phone";
                    break;
                case "Driver License":
                    ColumnFilter = "DriverLicense";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (txtFilterTextValue.Text.Trim() == "" || txtFilterTextValue.Text == null)
            {
                _AllCustomers.DefaultView.RowFilter = "";
                lbTotalCustomers.Text = "#" + dgvCustomersList.Rows.Count.ToString();
                return;
            }

            if (ColumnFilter == "CustomerID" || ColumnFilter == "Phone" || ColumnFilter == "DriverLicense")
               // dgvCustomersList.DataSource = string.Format("[0] = {1}", ColumnFilter, txtFilterTextValue.Text.Trim());
               _AllCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, txtFilterTextValue.Text.Trim());
            else
               // dgvCustomersList.DataSource = string.Format("[0] like '{1%}'", ColumnFilter, txtFilterTextValue.Text.Trim());
            _AllCustomers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnFilter, txtFilterTextValue.Text.Trim());
            // dgvCustomersList.DataSource = dtAllCustomers;


            lbTotalCustomers.Text = "#" + dgvCustomersList.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "None")
            {
                txtFilterTextValue.Enabled = false;

            }
            else
            {
                txtFilterTextValue.Focus(); 
                txtFilterTextValue.Enabled = true;
            }
        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(cbFilterBy.Text ==  "Customer ID" || cbFilterBy.Text == "Phone" || cbFilterBy.Text == "Driver License")
            {
                
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

            }
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerID =(int) dgvCustomersList.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you Sure to delete this Customer ", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;

            }
            else
            {
                if(ClsCustomer.DeleteCustomerByID(CustomerID))
                {
                    MessageBox.Show("Delete Customer with ID " + CustomerID.ToString(), " Success Deleted");
                    frmShowListCustomers_Load(null, null);
                    return;
                }
                else
                {
                    MessageBox.Show("Failed In Delete  Customer");
                }
            }
        }

        private void showDateilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerID = (int)dgvCustomersList.CurrentRow.Cells[0].Value;

            frmShowCustomerInfo frm = new frmShowCustomerInfo(CustomerID);
            frm.ShowDialog();
        }
    }
}
