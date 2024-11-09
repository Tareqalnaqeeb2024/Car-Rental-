using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace DataBusiness
{
    public class ClsCustomer
    {
         public enum EnMode { Add=1 , Update =2};

        public EnMode Mode = EnMode.Add;
         
        public  int CustomerID { set; get; }
         public string Name { set; get; }
        public string NationalID { set; get; }
        public string Address { set; get; }
        public string Email { set; get;  }
        public int Phone { set; get; }
        public int DriverLicense { set; get; }

        public ClsCustomer(int customerID, string name, string nationalID, string address, string email, int phone, int driverLicense)
        {
           this.CustomerID = customerID;
            this.Name = name;
           this.NationalID = nationalID;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.DriverLicense = driverLicense;

            Mode = EnMode.Update;
        }

        public ClsCustomer()
        {
            this.CustomerID = -1;
            this.Name = "";
            this.NationalID = "";
            this.Address = "";  
            this.Email = "";
            this.Phone = -1;
            this.DriverLicense = -1;

            Mode = EnMode.Add;

        }

        private bool _AddNewCustomer()
        {
            this.CustomerID = ClsCustomersData.AddNewCustomer(this.Name, this.NationalID, this.Address, this.Email, this.Phone, this.DriverLicense);

            return (this.CustomerID > -1);
        }

         private bool _UpdateCustomerByID()
        {
            return ClsCustomersData.UpdateCustomerByID(this.CustomerID, this.Name, this.NationalID, this.Address, this.Email, this.Phone, this.DriverLicense);
        }

        public static ClsCustomer GetCustomerByID(int CustomerID)
        {


            string Name = "", Email = "", Address = "";
            string NationalID = ""; int Phone = 0, DriverLicense = 0;


           if(ClsCustomersData.GetCustomerByID(CustomerID,ref Name,ref NationalID, ref Address ,ref Email, ref Phone,ref DriverLicense))
            {
                return new ClsCustomer(CustomerID, Name, NationalID, Address, Email, Phone, DriverLicense);
            }
           else
            {
                return null;
            }



        }

        public static bool CheckIsCustomerExists(int CustomerId)
        {
            return ClsCustomersData.CheckIsCustomerExists(CustomerId);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.Add:
                    if(_AddNewCustomer())
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
                        return _UpdateCustomerByID();
                    }
                
            }
            return false;
        }

        public static DataTable GetAllCustomers()
        {
            return ClsCustomersData.GetAllCustomers();
        }

        public static bool DeleteCustomerByID(int CustomerID)
        {
            return ClsCustomersData.DeleteCustomerByID(CustomerID);
        }
    }

}
