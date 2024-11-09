using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace DataBusiness
{
	public class ClsVehicles
	{
		//@VehicleID int ,
		//      @Make nvarchar(50),
		//@Model nvarchar(50),
		//@MadeYear int ,
		//@Mileage int ,
		//@FuleTypeID int ,
		//@PlateNumberID int,
		//@RentalPricePerDay decimal,
		//@IsAvailable bit,
		//@ImagePath nvarchar(200)
        public enum EnMode { Add = 1 , Update = 2};
        public EnMode Mode = EnMode.Add; 

		public int VehicleID { get; set; }
		public string Make { get; set; }
		public string Model { set; get; }
		public int MadeYear { set; get; }
		public int Mileage { set; get; }
		public int FuleTypeID { set; get; }
		public int PlateNumberID { set; get; }
		public decimal RentalPricePerDay { set; get; }
		public bool IsAvailable { set; get; }
		public string ImagePath { set; get; }

        public ClsVehicles(int vehicleID, string make, string model, int madeYear, int mileage,
			int fuleTypeID, int plateNumberID, decimal rentalPricePerDay, bool isAvailable, string imagePath)
        {
            this.VehicleID = vehicleID;
            this.Make = make;
            this.Model = model;
            this.MadeYear = madeYear;
            this.Mileage = mileage;
            this.FuleTypeID = fuleTypeID;
            this.PlateNumberID = plateNumberID;
            this.RentalPricePerDay = rentalPricePerDay;
            this.IsAvailable = isAvailable;
            this.ImagePath = imagePath;
            Mode = EnMode.Update;
        }

        public ClsVehicles()
        {
            this.VehicleID =    -1;
            this.Make =          "";
            this.Model =         "";
            this.MadeYear = 0;
            this.Mileage =       0;
            this.FuleTypeID=     -1;
            this.PlateNumberID=  -1;
            this.RentalPricePerDay= 0;
            this.IsAvailable =   false;
            this.ImagePath = "";
            Mode = EnMode.Add;

        }


        public bool AddNewVehicle()
        {

            this.VehicleID = ClsVehicleData.AddNewVehicle(this.Make, this.Model, this.MadeYear, this.Mileage, this.FuleTypeID, this.PlateNumberID,
                this.RentalPricePerDay, this.IsAvailable, this.ImagePath);

            return (this.VehicleID > 0);



        }

        public bool UpdateVehicle()
        {
           return ClsVehicleData.UpdateVehicle( this.VehicleID,this.Make, this.Model, this.MadeYear, this.Mileage, this.FuleTypeID, this.PlateNumberID,
                this.RentalPricePerDay, this.IsAvailable, this.ImagePath);
        }


         public static DataTable GetAllVehicles()
        {
            return ClsVehicleData.GetAllVechiles();
        }


        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.Add:

                    if(AddNewVehicle())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                 
                case EnMode.Update:
                    return UpdateVehicle();
                   
             
            }

            return false;
        }
      static  public ClsVehicles FindVehicleByID(int VehicleID )

        {

            
            string Make = "";
            string Model = "";
            int MadeYear = 0;
            int Mileage = 0;
            int FuleTypeID = -1;
            int PlateNumberID = 0;
            decimal RentalPricePerDay = 0;
            bool IsAvailable = false;
            string ImagePath = "";


            bool IsFound = ClsVehicleData.GetVehicleByID(VehicleID, ref Make, ref Model, ref MadeYear, ref Mileage,
                ref FuleTypeID, ref PlateNumberID, ref RentalPricePerDay, ref IsAvailable, ref ImagePath);

            if (IsFound)
            {
                return new ClsVehicles(VehicleID, Make, Model, MadeYear, Mileage, FuleTypeID, PlateNumberID, RentalPricePerDay,
                    IsAvailable, ImagePath);
            }
            else
            {
                return null;
            }

        }

      static  public ClsVehicles  GetVehiclesByID2(int VehicleID)
        {
           
            string Make = "";
            string Model = "";
           int  MadeYear = 0;
           int  Mileage = 0;
           int  FuleTypeID = 0;
           int  PlateNumberID = 0;
           decimal  RentalPricePerDay = 0;
            bool IsAvailable = false;
            string ImagePath = "";


            bool ISFound = ClsVehicleData.GetVehicleByID2(VehicleID);

            if (ISFound)
            
                return new ClsVehicles(VehicleID, Make, Model, MadeYear, Mileage, FuleTypeID, PlateNumberID, RentalPricePerDay,
                    IsAvailable, ImagePath);

            
            else
            
                return null;
            



        }

       static public bool DeleteVehicleByID(int VehicleID)
        {
            return ClsVehicleData.DeleteVehicleByID(VehicleID);
        }

        static public bool CheckVehicleExists(int VehicleID)
        {
            return ClsVehicleData.CheckIsVehicleExists(VehicleID);
        }
        static public bool IsVehicleAvialable(int VehicleID)
        {
            return ClsVehicleData.IsVehicleAvialable(VehicleID);
        }
    }
}
