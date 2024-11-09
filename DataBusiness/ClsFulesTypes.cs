using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using DataAccess;
namespace DataBusiness
{
   public  class ClsFulesTypes
    {
        public int FuleTypeID { get; set; }
        public string FuleTypeName { set; get; }

        public ClsFulesTypes(int fuleTypeID, string fuleTypeName)
        {
            FuleTypeID = fuleTypeID;
            FuleTypeName = fuleTypeName;
        }

        //public ClsFulesTypes()
        //{
        //    FuleTypeID = fuleTypeID;
        //    FuleTypeName = fuleTypeName;
        //}

        static public DataTable GetAllFulesTypesName()
        {
           return  ClsFulesTypeNameData.GetAllFulesTypesName();
        }

        static public ClsFulesTypes GetFuleTypeByID(int FuleID)
        {
            string FuleName = "";
            if(ClsFulesTypeNameData.GetFuleTypeNameByID(FuleID,ref FuleName) )
            {
                return new ClsFulesTypes(FuleID, FuleName);
            }else
            {
                return null;
            }
        }
    }
}
