using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace DataBusiness
{
   public class ClsTransaction
    {
        public enum EnMode { Add=1, Update =2 };
        public EnMode Mode = EnMode.Add;
        public int TransactionID { set; get; }

        public int BookingID { set; get; }
       public int ReturnID { set; get; } 
        public string PaymentDetails { set; get; }
        public decimal PaidInitialTotalDueAmount { set; get; }
       public decimal ActualTotalDueAmount { set; get; }
            public decimal TotalRemaining { set; get; }
        public decimal TotalRefunedAmount { set; get; } 
        public DateTime TransactionDate { set; get; }
        public DateTime UpdatedTransactionDate { set; get; }

        public ClsTransaction( int transactionID, int bookingID, int returnID, string paymentDetails, decimal paidInitialTotalDueAmount, decimal actualTotalDueAmount, decimal totalRemaining, decimal totalRefunedAmount, DateTime transactionDate, DateTime updatedTransactionDate)
        {
            Mode = EnMode.Update;
            this.TransactionID = transactionID;
            this.BookingID = bookingID;
            this.ReturnID = returnID;
            this.PaymentDetails = paymentDetails;
            this.PaidInitialTotalDueAmount = paidInitialTotalDueAmount;
            this.ActualTotalDueAmount = actualTotalDueAmount;
            this.TotalRemaining = totalRemaining;
            this.TotalRefunedAmount = totalRefunedAmount;
            this.TransactionDate = transactionDate;
            this.UpdatedTransactionDate = updatedTransactionDate;
        }

        public ClsTransaction()
        {
            this.TransactionID = -1;
            this.BookingID = -1;
            this.ReturnID = -1;
            this.PaymentDetails = "";
            this.PaidInitialTotalDueAmount = 0;
            this.ActualTotalDueAmount = 0;
            this.TotalRemaining = 0;
            this.TotalRefunedAmount = 0;
            this.TransactionDate = DateTime.Now;
            this.UpdatedTransactionDate = DateTime.Now;
            Mode = EnMode.Add;

        }


        private bool AddNewTransaction()
        {
            this.TransactionID = ClsTransactionData.AddNewTransaction(this.BookingID, this.ReturnID, this.PaymentDetails, this.PaidInitialTotalDueAmount,
                this.ActualTotalDueAmount, this.TotalRemaining, this.TotalRefunedAmount, this.TransactionDate, this.UpdatedTransactionDate);

            return (this.TransactionID > -1);
        }

        public bool UpdateTransaction()
        {
            return ClsTransactionData.UpdateTransactionByID(this.TransactionID, this.BookingID, this.ReturnID, this.PaymentDetails, this.PaidInitialTotalDueAmount,
                this.ActualTotalDueAmount, this.TotalRemaining, this.TotalRefunedAmount, this.TransactionDate, this.UpdatedTransactionDate);
        }

        public  bool Save()
        {
            switch (Mode)
            {
                case EnMode.Add:
                    if (AddNewTransaction())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    
                case EnMode.Update:
                    return UpdateTransaction();
                    
                       
                    
                    
               
                   
            }
            return false;
        }


        static public DataTable GetAllTransaction()
        {
            return ClsTransactionData.GetAllTransactions();
        }

        static public   ClsTransaction GetTransactionByID(int TransactionID)
        {
            bool IsFound = false;
            int BookingID = -1;
            int ReturnID = -1;
            string PaymentDetails = "";
            decimal PaidInitialTotalDueAmount = 0;
            decimal ActualTotalDueAmount =0;
            decimal TotalRemaining = 0;
            decimal TotalRefunedAmount = 0;
            DateTime TransactionDate = DateTime.Today;
            DateTime UpdatedTransactionDate = DateTime.Today;

             IsFound = ClsTransactionData.GetTransactionByID(TransactionID, ref BookingID, ref ReturnID,
                ref PaymentDetails, ref PaidInitialTotalDueAmount, ref ActualTotalDueAmount, ref TotalRemaining,
                ref TotalRefunedAmount, ref TransactionDate, ref UpdatedTransactionDate);
           

            if (IsFound)
            {
                return new ClsTransaction(TransactionID, BookingID, ReturnID, PaymentDetails, PaidInitialTotalDueAmount, ActualTotalDueAmount, TotalRemaining, TotalRefunedAmount, TransactionDate, UpdatedTransactionDate);
            }
            else
            {
                return null;
            }
        }

        public  bool DeleteTransactionByID(int TransactionID)
        {
            return ClsTransactionData.DeleteTransactionByID(TransactionID);
        }
    }
}
