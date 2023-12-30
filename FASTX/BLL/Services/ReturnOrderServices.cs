using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReturnOrderServices
    {
        public static List<ReturnOrderDTO> Get()
        {
            var data = DataAccessFactory.ReturnOrderData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReturnOder, ReturnOrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ReturnOrderDTO>>(data);
            return mapped;
        }
        public static ReturnOrderDTO Get(string id)
        {
            var data = DataAccessFactory.ReturnOrderData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReturnOder, ReturnOrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ReturnOrderDTO>(data);
            return mapped;
        }
    }
}
