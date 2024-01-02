using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FASTX.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/admin/coupon/create")]
        public HttpResponseMessage Create(ManagerSalaryDTO data)
        {
            try
            {
                AdminServices.CreateSalary(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/admin/salary/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminServices.GetAllSalary();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
