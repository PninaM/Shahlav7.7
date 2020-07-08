using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class CustomerLogic : BaseLogic
    {
        public ShachlavDB2 db = new ShachlavDB2();
        //public BaseLogic bl = new BaseLogic();
        //getCustomer-V
        //    getAllCustomers-V
        //    deletCustomer-V
        //    updateCustomer
        //    addCustomer-V
        //copy all customer fields




        //public CustomerDto getCustomer(int id)
        //{
        //    Customer c = db.Customers.First(c1 => c1.Id == id);
        //    return DaltoDto(c);
        //}

        public CustomerDto getCustomer(int x)
        {
            //try
            //{
                //Customer c = db.Customers.First(c1 => c1.Id == id);
                Customer c = db.Customers.FirstOrDefault(c1=>c1.Id==x);
                return DaltoDto(c);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            
      

        }

        public List<CustomerDto> getAllCustomers()
        {
            List<CustomerDto> lCustomers = new List<CustomerDto>();
            foreach (Customer c in db.Customers)
            {
                lCustomers.Add(DaltoDto(c));
            }

            return lCustomers;
        }

        //public void deleteCustomer(CustomerDto c)
        //{
        //    Customer c1 = DtoToDal(c);

        //    if (IsExists(c1))
        //        db.Customers.Remove(c1);

        //}

          public void deleteCustomer(int x)
        {
            Customer c = new Customer();
            c = DtoToDal(getCustomer(x));
            if (c != null)
                db.Customers.Remove(c);
        }

        public void addCustomer(CustomerDto c)
        {
            //bl.Test();
            
            Customer c1 = DtoToDal(c);
            if (!IsExists(c1))
                db.Customers.Add(new Customer() {Id=1, IdentityNumber="253810000", FirstName = "Pnina", LastName = "Menachem", CompanyName = "aa", BusinessCode = "12", Email = "pm@.com", PhoneNumber = "08974001", CellNumber = "0527180225", Address = "Netivot Hamishpat 86 Moddin I", UserName = "pmenachem", Password = "123456", BirthDate = DateTime.Today });
            db.SaveChanges();

        }

        public void updateCustomer(CustomerDto c)
        {
            Customer c1 = DtoToDal(c);
            foreach (Customer cFound in db.Customers)
            {
                if (cFound.Id == c1.Id)
                {
                    cFound.FirstName = c1.FirstName;
                    cFound.Address = c1.Address;
                    cFound.BirthDate = c1.BirthDate;
                    cFound.CellNumber = c1.CellNumber;
                    cFound.Email = c1.Email;
                    cFound.IdentityNumber = c1.IdentityNumber;
                    cFound.Password = c1.Password;
                    cFound.LastName = c1.LastName;
                    cFound.PhoneNumber = c1.PhoneNumber;
                    cFound.UserName = c1.UserName;
                    cFound.CompanyName = c1.CompanyName;
                    cFound.BusinessCode = c1.BusinessCode;
                }
            }

        }

        public bool IsExists(Customer c)
        {
            if (db.Customers.FirstOrDefault(ce => ce.Id == c.Id) != null)
                return true;
            else return false;
        }

        public CustomerDto DaltoDto(Customer d)
        {
            return new CustomerDto()
            {
                FirstName = d.FirstName,
                Address = d.Address,
                BirthDate = d.BirthDate,
                CellNumber = d.CellNumber,
                Email = d.Email,
                IdentityNumber = d.IdentityNumber,
                Password = d.Password,
                LastName = d.LastName,
                PhoneNumber = d.PhoneNumber,
                UserName = d.UserName,
                BusinessCode = d.BusinessCode,
                CompanyName = d.CompanyName,
                Id = d.Id
            };
        }

        public Customer DtoToDal(CustomerDto c)
        {
            return new Customer()
            {

                FirstName = c.FirstName,
                Address = c.Address,
                //BirthDate = c.BirthDate,
                
                CellNumber = c.CellNumber,
                Email = c.Email,
                IdentityNumber = c.IdentityNumber,
                Password = c.Password,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                UserName = c.UserName,
                CompanyName = c.CompanyName,
                BusinessCode = c.BusinessCode,
                Id = c.Id

            };
        }
    }



}
