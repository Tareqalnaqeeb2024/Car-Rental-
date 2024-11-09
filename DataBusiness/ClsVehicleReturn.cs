using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace DataBusiness
{
    public class ClsVehicleReturn
    {

        public enum EnMode { Add=1 ,Update=2};
        public static EnMode Mode = EnMode.Add;
        public int ReturnID             {set; get;}
     public DateTime  ActualReturnDate     {set; get;}
     public  int ActualRentalDays     {set; get;}
     public  int Mileage              {set; get;}
     public int  ConsumedMileage      {set; get;}
     public  string FinalCheckNotes      {set; get;}
     public string  AddtionalCharges     {set; get;}
     public  decimal ActualTotalDueAmount {set; get;}

        public ClsVehicleReturn(int returnID, DateTime actualReturnDate, int actualRentalDays, int mileage, int consumedMileage, string finalCheckNotes, string addtionalCharges, decimal actualTotalDueAmount)
        {
            ReturnID =           returnID;
            ActualReturnDate =   actualReturnDate;
            ActualRentalDays =    actualRentalDays;
            Mileage =              mileage;
            ConsumedMileage =      consumedMileage;
            FinalCheckNotes =      finalCheckNotes;
            AddtionalCharges =     addtionalCharges;
            ActualTotalDueAmount = actualTotalDueAmount;

            Mode = EnMode.Update;
        }

        public ClsVehicleReturn()
        {
            ReturnID = -1;
            ActualReturnDate = DateTime.Now;
            ActualRentalDays = 0;
            Mileage = 0;
            ConsumedMileage = 0;
            FinalCheckNotes = "";
            AddtionalCharges = "";
            ActualTotalDueAmount = 0;

            Mode = EnMode.Add;
        }

        public static  ClsVehicleReturn FindVehicleReturnByID(int ReturnID)
        {

            bool IsFound ;

            DateTime ActualReturnDate = DateTime.Now;
            int ActualRentalDays = 0;
            int Mileage = 0;
            int  ConsumedMileage = 0;
            string  FinalCheckNotes = "";
           string  AddtionalCharges = "";
            decimal ActualTotalDueAmount = 0;

            IsFound = ClsVehicleReturnData.FindVehicleReturnByID(ReturnID, ref ActualReturnDate,
                ref ActualRentalDays, ref Mileage, ref ConsumedMileage, ref FinalCheckNotes, ref AddtionalCharges,
                ref ActualTotalDueAmount);


            if (IsFound)
            {
                return new ClsVehicleReturn(ReturnID, ActualReturnDate, ActualRentalDays, Mileage,
                    ConsumedMileage, FinalCheckNotes, AddtionalCharges, ActualTotalDueAmount);
            }
            else
            {
                return null;
            }




        }

        private bool _AddNewReturn()
        {
             this.ReturnID = ClsVehicleReturnData.AddNewReturn(this.ActualReturnDate, this.ActualRentalDays, this.Mileage,
                this.ConsumedMileage, this.FinalCheckNotes, this.AddtionalCharges, this.ActualTotalDueAmount);

            return (this.ReturnID > -1) ;
        }

        public bool _UpdateReturn( )
        {
            return ClsVehicleReturnData.UpdateReturn(this.ReturnID, this.ActualReturnDate, this.ActualRentalDays, this.Mileage,
                this.ConsumedMileage, this.FinalCheckNotes, this.AddtionalCharges, this.ActualTotalDueAmount);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.Add:
                    if(_AddNewReturn())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EnMode.Update:

                    return _UpdateReturn();
            }

            return false;
        }



        public static DataTable GetAllVehiclesReturns()
        {
            return ClsVehicleReturnData.GetAllReturns();
        }

       
        public static bool DeleteVehicleReturn(int ReturnID)
        {
            return ClsVehicleReturnData.DeleteReturnID(ReturnID);
        }

    }
}
