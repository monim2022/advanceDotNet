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
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/report")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ReportServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/report/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = ReportServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/report/create")]
        public HttpResponseMessage Create([FromBody] ReportDTO reportDTO)
        {
            try
            {
                if (reportDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = ReportServices.Create(reportDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Report created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/report/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] ReportDTO reportDTO)
        {
            try
            {
                if (reportDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                reportDTO.ReportId = id;

                var data = ReportServices.Update(reportDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Report updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/report/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = ReportServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Report deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Report not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
