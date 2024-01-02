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
        [HttpGet]
        [Route("api/admin")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = AdminServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = AdminServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/admin/create")]
        public HttpResponseMessage Create([FromBody] AdminDTO adminDTO)
        {
            try
            {
                if (adminDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = AdminServices.Create(adminDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Admin created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/admin/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] AdminDTO adminDTO)
        {
            try
            {
                if (adminDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                adminDTO.AdminId = id;

                var data = AdminServices.Update(adminDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Admin updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/admin/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = AdminServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Admin deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Admin not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
