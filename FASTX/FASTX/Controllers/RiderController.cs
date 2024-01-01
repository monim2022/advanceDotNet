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
    public class RiderController : ApiController
    {
        [HttpGet]
        [Route("api/rider")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = RiderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/rider/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = RiderService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/rider/create")]
        public HttpResponseMessage Create([FromBody] RiderDTO riderDTO)
        {
            try
            {
                if (riderDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = RiderService.Create(riderDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Rider created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/rider/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] RiderDTO riderDTO)
        {
            try
            {
                if (riderDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                riderDTO.BranchId = id;

                var data = RiderService.Update(riderDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Rider updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/rider/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = RiderService.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Rider deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Rider not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
