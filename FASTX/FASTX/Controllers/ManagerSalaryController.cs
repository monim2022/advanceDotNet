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
    public class ManagerSalaryController : ApiController
    {
        [HttpGet]
        [Route("api/managersallist")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ManagerSalaryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/managersallist/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = ManagerSalaryService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/managersalarycreate/create")]
        public HttpResponseMessage Create([FromBody] ManagerSalaryDTO managerSalaryDTO)
        {
            try
            {
                if (managerSalaryDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = ManagerSalaryService.Create(managerSalaryDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Manager Salary created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/managersalary/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] ManagerSalaryDTO managerSalaryDTO)
        {
            try
            {
                if (managerSalaryDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                managerSalaryDTO.ManagerSalId = id;

                var data = ManagerSalaryService.Update(managerSalaryDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Manager Salary updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/managersalary/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = ManagerSalaryService.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Manager Salary deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Manager Salary not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

    }
}
