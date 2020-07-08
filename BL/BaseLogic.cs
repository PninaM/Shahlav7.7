using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BaseLogic : IDisposable
    {
        //public ShachlavDB2 db = new ShachlavDB2();


        public void Test()
        {
            using (ShachlavDB2 TestDb = new ShachlavDB2())
            {

                //TestDb.Material.Add(new Material() { Id = 1, Name = "tt1111" });
                TestDb.Customers.Add(new Customer() { Id = 1, FirstName = "Pnina", LastName = "Menachem", CompanyName = "aa", BusinessCode = "12", Email = "pm@.com", PhoneNumber = "08974001", CellNumber = "0527180225", Address = "Netivot Hamishpat 86 Moddin I", UserName = "pmenachem", Password = "123456", BirthDate = DateTime.Today });
                TestDb.SaveChanges();
            }
        }
        public void Dispose()
        {
           
        }
    }
   
}
