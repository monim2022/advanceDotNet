using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeliveryStatusService
    {
        private static readonly IMapper mapper;

        static DeliveryStatusService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DeliveryStatus, DeliveryStatusDTO>();
                c.CreateMap<DeliveryStatusDTO, DeliveryStatus>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<DeliveryStatusDTO> Get()
        {
            var data = DataAccessFactory.DeliveryStatusData().Read();
            var mapped = mapper.Map<List<DeliveryStatusDTO>>(data);
            return mapped;
        }


        public static DeliveryStatusDTO GetById(int id)
        {
            var data = DataAccessFactory.DeliveryStatusData().Read(id);
            var mapped = mapper.Map<DeliveryStatusDTO>(data);
            return mapped;
        }

        public static DeliveryStatusDTO Create(DeliveryStatusDTO deliveryStatusDTO)
        {
            var deliveryStatus = mapper.Map<DeliveryStatus>(deliveryStatusDTO);
            var data = DataAccessFactory.DeliveryStatusData().Create(deliveryStatus);
            return mapper.Map<DeliveryStatusDTO>(data);
        }

        public static DeliveryStatusDTO Update(DeliveryStatusDTO deliveryStatusDTO)
        {
            var deliveryStatus = mapper.Map<DeliveryStatus>(deliveryStatusDTO);
            var data = DataAccessFactory.DeliveryStatusData().Update(deliveryStatus);
            return mapper.Map<DeliveryStatusDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.DeliveryStatusData().Delete(id);
            if (isSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
