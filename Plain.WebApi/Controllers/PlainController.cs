using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plain.WebApi.Controllers
{
    [Route("api/plain")]
    public class PlainController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "Hello Plain Jane");

            return response;
        }
    }
}
