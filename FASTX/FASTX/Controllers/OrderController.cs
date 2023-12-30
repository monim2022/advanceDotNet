using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FASTX.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/Orderslist")]
        public HttpResponseMessage Orders()
        {
            try
            {
                var data = OrderServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
    }
}
