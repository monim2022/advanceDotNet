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
    public class RiderService
    {
        private static readonly IMapper mapper;

        static RiderService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Rider, RiderDTO>();
                c.CreateMap<RiderDTO, Rider>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<RiderDTO> Get()
        {
            var data = DataAccessFactory.RiderData().Read();
            var mapped = mapper.Map<List<RiderDTO>>(data);
            return mapped;
        }


        public static RiderDTO GetById(int id)
        {
            var data = DataAccessFactory.RiderData().Read(id);
            var mapped = mapper.Map<RiderDTO>(data);
            return mapped;
        }

        public static RiderDTO Create(RiderDTO riderDTO)
        {
            var rider = mapper.Map<Rider>(riderDTO);
            var data = DataAccessFactory.RiderData().Create(rider);
            return mapper.Map<RiderDTO>(data);
        }

        public static RiderDTO Update(RiderDTO riderDTO)
        {
            var rider = mapper.Map<Rider>(riderDTO);
            var data = DataAccessFactory.RiderData().Update(rider);
            return mapper.Map<RiderDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.RiderData().Delete(id);
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
