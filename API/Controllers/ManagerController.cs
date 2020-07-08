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
    [RoutePrefix("api/Manager")]
    public class ManagerController : ApiController
    {
        ManagerLogic m = new ManagerLogic();
        //[Route("Get")]
        //[HttpGet]
        //public string GetUser(int x)
        //{
        //    return ("dfgg");
        //}
        [Route("Get")]
        [HttpGet]
        public ManagerDto GetManager(int x)
        {

            return m.getManager(x);
        }
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddManager(ManagerDto x)
        {
            try
            {
                m.addManager(x);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest("fff");
            }
        }


        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult DeleteManager(int x)
        {
            try
            {
                m.deleteManager(x);
                return Ok("jhgg");
            }
            catch
            {
                return BadRequest("ggf");
            }
        }

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateManager(ManagerDto x)
        {
            try
            {
                m.updateManager(x);
                return Ok("success");
            }
            catch
            {
                return BadRequest("fds");
            }
        }
    }
}
