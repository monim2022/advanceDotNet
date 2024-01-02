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
    public class DeliveryStatusController : ApiController
    {
        [HttpGet]
        [Route("api/delivery-status")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = DeliveryStatusService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/delivery-status/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = DeliveryStatusService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/delivery-status/create")]
        public HttpResponseMessage Create([FromBody] DeliveryStatusDTO deliveryStatusDTO)
        {
            try
            {
                if (deliveryStatusDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = DeliveryStatusService.Create(deliveryStatusDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Delivery Status created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/delivery-status/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] DeliveryStatusDTO deliveryStatusDTO)
        {
            try
            {
                if (deliveryStatusDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                deliveryStatusDTO.Id = id;

                var data = DeliveryStatusService.Update(deliveryStatusDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Delivery Status updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/delivery-status/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = DeliveryStatusService.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Delivery Status deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Delivery Status not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
