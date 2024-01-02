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
        [Route("api/admin/salary/create")]
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

        [HttpPost]
        [Route("api/admin/Reporty/create")]
        public HttpResponseMessage Create(ReportDTO data)
        {
            try
            {
                AdminServices.CreateReport(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/admin/Report/all")]
        public HttpResponseMessage GetAllReport()
        {
            try
            {
                var data = AdminServices.GetAllReport();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }




    }
}
