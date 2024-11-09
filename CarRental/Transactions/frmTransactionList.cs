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

namespace CarRental.Transactions
{
    public partial class frmTransactionList : Form
    {
        


        public int TransactionID;
        public ClsTransaction _Transaction;
        public static DataTable _dtAllTransaction = ClsTransaction.GetAllTransaction();
        public DataTable dtTransaction = _dtAllTransaction.DefaultView.ToTable(false, "TransactionID", "BookingID", "ReturnID", "PaymentDetails", "PaidInitialTotalDueAmount", "ActualTotalDueAmount", "TotalRemaining",
            "TotalRefunedAmount", "TransactionDate", "UpdatedTransactionDate");
        public frmTransactionList()
        {
            InitializeComponent();
        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
            dgvTransactionList.DataSource = dtTransaction;
            lbTotalTransaction.Text = dgvTransactionList.Rows.Count.ToString();

            cbFilterBy.Text = "None";
            if (dgvTransactionList.Rows.Count > 0)
            {
                dgvTransactionList.Columns[0].HeaderText = "Transaction ID";
                dgvTransactionList.Columns[0].Width = 80;

                dgvTransactionList.Columns[1].HeaderText = "Booking ID";
                dgvTransactionList.Columns[1].Width = 80;

                dgvTransactionList.Columns[2].HeaderText = "Return ID";
                dgvTransactionList.Columns[2].Width = 80;

                dgvTransactionList.Columns[3].HeaderText = "Payment Details";
                dgvTransactionList.Columns[3].Width = 100;

                dgvTransactionList.Columns[4].HeaderText = "Paid Initial Total DueAmount";
                dgvTransactionList.Columns[4].Width = 100;

                dgvTransactionList.Columns[5].HeaderText = "Actual Total Due Amount";
                dgvTransactionList.Columns[5].Width = 100;

                dgvTransactionList.Columns[6].HeaderText = "Total Remaining";
                dgvTransactionList.Columns[6].Width = 100;


                dgvTransactionList.Columns[7].HeaderText = "Total Refuned Amount";
                dgvTransactionList.Columns[7].Width = 100;

                dgvTransactionList.Columns[8].HeaderText = "Transaction Date";
                dgvTransactionList.Columns[8].Width = 110;

                dgvTransactionList.Columns[9].HeaderText = "Updated Transaction Date";
                dgvTransactionList.Columns[9].Width = 110;

            }

        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Transaction ID":
                    ColumnFilter = "TransactionID";
                        break;
                case "Booking ID":
                    ColumnFilter = "BookingID";
                    break;
                case "Return ID":
                    ColumnFilter = "ReturnID";
                    break;

                default:
                    ColumnFilter = "None";
                    break;
            }

            if (txtFilterTextValue.Text.Trim() == "" || ColumnFilter == "")
            {
                dtTransaction.DefaultView.RowFilter = "";
                lbTotalTransaction.Text = dgvTransactionList.Rows.Count.ToString();
                return;
            }

          //  if (ColumnFilter == "TransactionID" || ColumnFilter == "BookingID" || ColumnFilter == "ReturnID")
            if(ColumnFilter != "None")

                dtTransaction.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, txtFilterTextValue.Text.Trim());

                lbTotalTransaction.Text = dgvTransactionList.Rows.Count.ToString();
            
            
        }

      
        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterTextValue.Enabled = cbFilterBy.Text != "None";

            if(cbFilterBy.Text != "None")
            {
                txtFilterTextValue.Enabled = true;
                txtFilterTextValue.Focus();
            }
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateTransaction frm = new frmAddUpdateTransaction();
            frm.ShowDialog();
        }
    }
}
