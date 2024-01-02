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
    public class AdminServices
    {
        private static readonly IMapper mapper;

        static AdminServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
                c.CreateMap<AdminDTO, Admin>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Read();
            var mapped = mapper.Map<List<AdminDTO>>(data);
            return mapped;
        }


        public static AdminDTO GetById(int id)
        {
            var data = DataAccessFactory.AdminData().Read(id);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }

        public static AdminDTO Create(AdminDTO adminDTO)
        {
            var admin = mapper.Map<Admin>(adminDTO);
            var data = DataAccessFactory.AdminData().Create(admin);
            return mapper.Map<AdminDTO>(data);
        }

        public static AdminDTO Update(AdminDTO adminDTO)
        {
            var admin = mapper.Map<Admin>(adminDTO);
            var data = DataAccessFactory.AdminData().Update(admin);
            return mapper.Map<AdminDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.AdminData().Delete(id);
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
