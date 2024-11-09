using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess;


namespace DataBusiness
{
   public class ClsPlateDetails
    {
        
        public enum EnMode { AddNew = 1 , Update = 2};
        public EnMode Mode = EnMode.Update;
        public int PlateID { set; get; }
        public int PlateNumber { set; get; }
        public string PlateType { set; get; }
        public int CityNumber { set; get; }

        public ClsPlateDetails(int PlateID, int plateNumber, string plateType, int cityNumber)
        {
            this.PlateID = PlateID;
           this.PlateNumber = plateNumber;
           this.PlateType = plateType;
           this.CityNumber = cityNumber;
            Mode = EnMode.Update;
        }

        public ClsPlateDetails()
        {
            this.PlateNumber = 0;
            this.PlateType = "";
            this.CityNumber = 0;

            Mode = EnMode.AddNew;
        }

        private bool _AddNewPlate()
        {
            this.PlateID = ClsPlateDetailsData.AddNewPlate(this.PlateNumber, this.PlateType, this.CityNumber);

            return (this.PlateID > 0);
        }

        private bool _UpdatePlate()
        {
            return ClsPlateDetailsData.UpdatePlate(this.PlateID, this.PlateNumber, this.PlateType, this.CityNumber);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.AddNew:

                    if (_AddNewPlate())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                   
                case EnMode.Update:

                    return _UpdatePlate();

            }
            return false;
        }



        static public ClsPlateDetails GetPlatDetailsByID(int PlateID)
        {
           int PlateNumber = 0;
          string   PlateType = "";
           int CityNumber = 0;


            bool IsFound = ClsPlateDetailsData.GetPlateDetailsByID(PlateID, ref PlateNumber, ref PlateType, ref CityNumber);


            if (IsFound)
            {
                return new ClsPlateDetails(PlateID, PlateNumber, PlateType, CityNumber);
            }
            else
            {
                return null;
            }

        }

        static public ClsPlateDetails GetPlatDetailsByPlateNumber(int PlateNumber)
        {
            int PlateID = 0;
            string PlateType = "";
            int CityNumber = 0;


            bool IsFound = ClsPlateDetailsData.GetPlateDetailsByPlateNumber(  PlateNumber,ref  PlateID, ref PlateType, ref CityNumber);


            if (IsFound)
            {
                return new ClsPlateDetails(PlateID, PlateNumber, PlateType, CityNumber);
            }
            else
            {
                return null;
            }

        }

        static public bool DeletePlateDetailByID(int PlateID)
        {
            return ClsPlateDetailsData.DeletePlateDetailsByID(PlateID);
        }

       
    }
}
