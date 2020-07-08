using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        CustomerLogic c = new CustomerLogic();

        [Route("Get")]
        [HttpGet]   
        public CustomerDto GetCustomer(int x)
        {
            return c.getCustomer(x);
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto c1)
        {
            try
            {
                c.addCustomer(c1);
                return Ok("succ");
            }
            catch (Exception ex){
                return BadRequest("err");
            }

        }
        //לא ניגש מהקליינט
        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int x)
        {
            c.deleteCustomer(x);
            try { return Ok("succ"); }
            catch { return BadRequest("err"); }
        }


        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateCustomer(CustomerDto c1)
        {
            try { c.updateCustomer(c1);
                return Ok("succ");
            }
            catch { return BadRequest("err"); }
        }
    }
}
