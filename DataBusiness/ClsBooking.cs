using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace DataBusiness
{
  public  class ClsBooking
    {
       

        public enum EnMode { Add =1 , Update =2};
        public EnMode Mode = EnMode.Add;
        public int BookingID { set; get; }
       public  int CustomerID { set; get; } 
       public  int VehicleID { set; get; }
       public  DateTime StartDate { set; get; }
       public  DateTime EndDate { set; get; } 
       public  string PickUpLocation { set; get; }
       public  string DropOffLocation { set; get; }
       public  int InitialRentalDays { set; get; }
       public  decimal RentalPricePerDay { set; get; }
       public decimal InitialTotalDueAmount { set; get; }
       public  string InitialCheckNotes { set; get; }

        public ClsBooking(int BookingID, int customerID, int vehicleID, DateTime startDate, DateTime endDate, string pickUpLocation, string dropOffLocation, int initialRentalDays, decimal rentalPricePerDay, decimal initialTotalDueAmount, string initialCheckNotes)
        {
            this.BookingID = BookingID;
           this.CustomerID = customerID;
           this.VehicleID = vehicleID;
           this.StartDate = startDate;
           this.EndDate = endDate;
           this.PickUpLocation = pickUpLocation;
           this.DropOffLocation = dropOffLocation;
           this.InitialRentalDays = initialRentalDays;
           this.RentalPricePerDay = rentalPricePerDay;
           this.InitialTotalDueAmount = initialTotalDueAmount;
           this.InitialCheckNotes = initialCheckNotes;
            Mode = EnMode.Update;

        }

        public ClsBooking()
        {
            this.BookingID = -1;
            this.CustomerID=  -1;
            this.VehicleID = -1;
            this.StartDate = DateTime.Now;
            this.EndDate =    DateTime.Now;
            this.PickUpLocation = " ";
            this.DropOffLocation = "";
            this.InitialRentalDays = 0;
            this.RentalPricePerDay = 0;
            this.InitialTotalDueAmount = 0;
            this.InitialCheckNotes = "";
            Mode = EnMode.Add;
        }

        public bool AddNewBooking()
        {
            this.BookingID = ClsBookingData.AddNewBooking(this.CustomerID, this.VehicleID, this.StartDate, this.EndDate, this.PickUpLocation,
                this.DropOffLocation, this.InitialRentalDays, this.RentalPricePerDay, this.InitialTotalDueAmount,this.InitialCheckNotes);

            return (this.BookingID > 0);
        }

        public bool UpdateBooking()
        {
          return    ClsBookingData.UpdateBookingByID(this.BookingID, this.CustomerID, this.VehicleID, this.StartDate, this.EndDate, this.PickUpLocation,
                this.DropOffLocation, this.InitialRentalDays, this.RentalPricePerDay, this.InitialTotalDueAmount, this.InitialCheckNotes);

           
        }

        static public DataTable GetAllBookings()
        {
            return  ClsBookingData.GetAllBookings();
        }

      static   public ClsBooking GetBookingByID(int BookingID)
        {
           
           int CustomerID = -1;
          int  VehicleID = -1;
          DateTime  StartDate = DateTime.Now;
          DateTime  EndDate = DateTime.Now;
          string PickUpLocation = " ";
          string   DropOffLocation = "";
           int InitialRentalDays = 0;
           decimal RentalPricePerDay = 0;
           decimal InitialTotalDueAmount = 0;
          string  InitialCheckNotes = "";

            bool IsFound = ClsBookingData.GetBookingByID(BookingID, ref CustomerID, ref VehicleID, ref StartDate,
                ref EndDate, ref PickUpLocation, ref DropOffLocation, ref InitialRentalDays, ref RentalPricePerDay,
                ref InitialTotalDueAmount, ref InitialCheckNotes);

            if (IsFound)
            {
                return new ClsBooking(BookingID, CustomerID, VehicleID, StartDate, EndDate, PickUpLocation,
                    DropOffLocation, InitialRentalDays, RentalPricePerDay, InitialTotalDueAmount, InitialCheckNotes);
                    }
            else
            {
                return null;

            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.Add:
                    if (AddNewBooking())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                    
                case EnMode.Update:
                    {
                        return UpdateBooking();
                    }
                    
                default:
                    return false;
                    
            }
        }
        public static bool DeleteBookingByID(int BookingID)
        {
            return ClsBookingData.DeleteBookingByID(BookingID);
        }

       static public bool CheckBookingExists(int BookingID)
        {
            return ClsBookingData.CheckBookingExists(BookingID);
        }
    }
}
