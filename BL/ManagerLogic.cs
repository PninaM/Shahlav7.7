using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//addManager -V
//deleteManager-V
//updateManager-V
//getManager-V
//firstordefault

namespace BL
{
    public class ManagerLogic : BaseLogic
    {
        public ShachlavDB2 db = new ShachlavDB2();
        public ManagerDto getManager(int id)
        {
            using (var db1 = new ShachlavDB2())
            {
                Manager m = db1.Manager.FirstOrDefault(m1 => m1.Id == id);
                return ManagerToDto(m);
            }
        }

        public List<ManagerDto> getManagers()
        {
            List<ManagerDto> lManagers = new List<ManagerDto>();
            foreach (var m in db.Manager)
            {
                lManagers.Add(ManagerToDto(m));
            }
            return lManagers;
        }


        public void addManager(ManagerDto m)
        {
            Manager m1 = ManagerToDal(m);
            if (!IsExist(m1))
                db.Manager.Add(m1);
        }

        //public void deleteManager(ManagerDto m)
        //{
        //    Manager m1 = ManagerToDal(m);
        //    if (IsExist(m1))
        //        db.Manager.Remove(m1);
        //}

        public void deleteManager(int x)
        {
            Manager m = ManagerToDal(getManager(x));
            if (m != null)
                db.Manager.Remove(m);
        }

        public void updateManager(ManagerDto m)
        {
            Manager m1 = ManagerToDal(m);
            foreach (Manager mFound in db.Manager)
            {
                if (mFound.Id == m1.Id)
                {
                    mFound.FirstName = m1.FirstName;
                    mFound.Address = m1.Address;
                    mFound.BirthDate = m1.BirthDate;
                    mFound.CellNumber = m1.CellNumber;
                    mFound.Email = m1.Email;
                    mFound.IdentityNumber = m1.IdentityNumber;
                    mFound.Password = m1.Password;
                    mFound.LastName = m1.LastName;
                    mFound.PhoneNumber = m1.PhoneNumber;
                    mFound.UserName = m1.UserName;
                }
            }

        }


        //public static void AddManager(ManagerDto d)
        //{
        //    using (ShachlavDB1 TestDb = new ShachlavDB1())
        //    {
        //        TestDb.Driver.Add(ManagerLogic.DriverToDal(d));
        //        TestDb.SaveChanges();
        //    }

        //}

        public bool IsExist(Manager m)
        {
            if (db.Manager.First(ma => ma.Id == m.Id) != null)
                return true;
            else return false;

        }


        public Manager ManagerToDal(ManagerDto m)
        {
            return new Manager()
            {
                FirstName = m.FirstName,
                Address = m.Address,
                BirthDate = m.BirthDate,
                CellNumber = m.CellNumber,
                Email = m.Email,
                IdentityNumber = m.IdentityNumber,
                Password = m.Password,
                LastName = m.LastName,
                PhoneNumber = m.PhoneNumber,
                UserName = m.UserName,
                Id = m.Id
            };

        }
        public static ManagerDto ManagerToDto(Manager m)
        {
            return new ManagerDto() { FirstName = m.FirstName,
                Address = m.Address,
                BirthDate = m.BirthDate,
                CellNumber = m.CellNumber,
                Email = m.Email,
                IdentityNumber = m.IdentityNumber,
                Password = m.Password,
                LastName = m.LastName,
                PhoneNumber = m.PhoneNumber,
                UserName = m.UserName,
                Id = m.Id
            };

        }
    }
}
