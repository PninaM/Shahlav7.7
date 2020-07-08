using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Driver")]
    public class DriverController : ApiController
    {DriverLogic d = new DriverLogic();
        

        [Route("Get")]
        [HttpGet]
        public DriverDto GetDriver(int x)
        {
            int xv=5;
            return d.getDriver(x);

        }
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddDriver(DriverDto x)
        {
            try
            {
                d.addDriver(x);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest("fff");
            }
        }


        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult DeleteDriver(int x)
        {
            try
            {
                d.deleteDriver(x);
                return Ok("jhgg");
            }
            catch
            {
                return BadRequest("ggf");
            }
        }

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateDriver(DriverDto x)
        {
            try
            {
                d.updateDriver(x);
                return Ok("success");
            }
            catch
            {
                return BadRequest("fds");
            }
        }
    }


}