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
    public class RiderServices
    {
        public static List<RiderDTO> Get()
        {
            var data = DataAccessFactory.RiderData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<RiderDTO>>(data);
            return mapped;
        }
        public static RiderDTO Get(int RiderId)
        {
            var data = DataAccessFactory.RiderData().Read(RiderId);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<RiderDTO>(data);
            return mapped;

        }
    }
}
