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
    public class PaymentService
    {
        private static readonly IMapper mapper;

        static PaymentService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
                c.CreateMap<PaymentDTO, Payment>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataAccessFactory.PaymentData().Read();
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }


        public static PaymentDTO GetById(int id)
        {
            var data = DataAccessFactory.PaymentData().Read(id);
            var mapped = mapper.Map<PaymentDTO>(data);
            return mapped;
        }

        public static PaymentDTO Create(PaymentDTO paymentDTO)
        {
            var payment = mapper.Map<Payment>(paymentDTO);
            var data = DataAccessFactory.PaymentData().Create(payment);
            return mapper.Map<PaymentDTO>(data);
        }

        public static PaymentDTO Update(PaymentDTO paymentDTO)
        {
            var payment = mapper.Map<Payment>(paymentDTO);
            var data = DataAccessFactory.PaymentData().Update(payment);
            return mapper.Map<PaymentDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.PaymentData().Delete(id);
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
