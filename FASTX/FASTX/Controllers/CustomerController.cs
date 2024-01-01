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
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/customer")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = CustomersServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/customer/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = CustomersServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/customer/create")]
        public HttpResponseMessage Create([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = CustomersServices.Create(customerDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Customer created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/customer/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                customerDTO.CustomerId = id;

                var data = CustomersServices.Update(customerDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Customer updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/customer/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = CustomersServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Customer deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Customer not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
