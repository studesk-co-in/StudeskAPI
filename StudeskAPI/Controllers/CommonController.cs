using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudeskAPI.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonController : ApiController
    {
        [HttpGet]
        [Route("getvalue")]
        public string GetValue()
        {
            return "Value";
        }

    }
}