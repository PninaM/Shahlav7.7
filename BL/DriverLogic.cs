using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class DriverLogic : BaseLogic
    {
        public ShachlavDB2 db = new ShachlavDB2();

        //getDriver-V
        //    getAllDrivers-V
        //    deleteDriver-V
        //    updateDriver-V
        //    addDriver-V

        public DriverDto getDriver(int id)
        {
            try
            {
                Driver d = db.Driver.FirstOrDefault(de => de.Id == id);
                return DaltoDto(d);
            }
            catch(Exception ex)
            {
                LogFile.WriteError(ex.Message);
                return null;
            }
        }

        public List<DriverDto> getAllDrivers()
        {
            List<DriverDto> lDrivers = new List<DriverDto>();
            foreach (Driver d in db.Driver)
                lDrivers.Add(DaltoDto(d));
            return lDrivers;
        }

        //public void deleteDriver(DriverDto d)
        //{
        //    Driver d1 = DtoToDal(d);

        //   if (IsExists(d1))
        //        db.Driver.Remove(d1);
                
        //}

         public void deleteDriver(int x)
        {
            Driver d1 = DtoToDal(getDriver(x));
            if (d1 != null)
                db.Driver.Remove(d1);

        }

        public void addDriver(DriverDto d)
        {
            Driver d1=DtoToDal(d);
            if(!IsExists(d1))
            db.Driver.Add(d1);
        }

        public void updateDriver(DriverDto d)
        {
           Driver d1= DtoToDal(d);
            foreach(Driver dFound in db.Driver)
            {
                if(dFound.Id==d1.Id)
                {
                    dFound.FirstName = d1.FirstName;
                    dFound.Address = d1.Address;
                    dFound.BirthDate = d1.BirthDate;
                    dFound.CellNumber = d1.CellNumber;
                    dFound.Email = d1.Email;
                    dFound.IdentityNumber = d1.IdentityNumber;
                    dFound.Password = d1.Password;
                    dFound.LastName = d1.LastName;
                    dFound.PhoneNumber = d1.PhoneNumber;
                    dFound.UserName = d1.UserName;
                }
            }
        }

          public bool IsExists(Driver d)
        {
            if (db.Driver.First(de => de.Id == d.Id)!=null)
                return true;
            else return false;
        }

        public DriverDto DaltoDto(Driver d)
        {
            if(d!=null)
            return new DriverDto()
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
                Id = d.Id
            };
            else return null;
        }

        public Driver DtoToDal(DriverDto d)
        {
            return new Driver()
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
                Id = d.Id

            };
        }







    }
}
