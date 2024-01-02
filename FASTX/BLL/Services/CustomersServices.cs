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
    public class CustomersServices
    {
        private static readonly IMapper mapper;

        static CustomersServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
                c.CreateMap<CustomerDTO, Customer>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CoustomerData().Read();
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }


        public static CustomerDTO GetById(int id)
        {
            var data = DataAccessFactory.CoustomerData().Read(id);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }

        public static CustomerDTO Create(CustomerDTO customerDTO)
        {
            var customer = mapper.Map<Customer>(customerDTO);
            var data = DataAccessFactory.CoustomerData().Create(customer);
            return mapper.Map<CustomerDTO>(data);
        }

        public static CustomerDTO Update(CustomerDTO customerDTO)
        {
            var customer = mapper.Map<Customer>(customerDTO);
            var data = DataAccessFactory.CoustomerData().Update(customer);
            return mapper.Map<CustomerDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.CoustomerData().Delete(id);
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
