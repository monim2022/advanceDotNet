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
    public class PackageService
    {
        private static readonly IMapper mapper;

        static PackageService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Package, PackageDTO>();
                c.CreateMap<PackageDTO, Package>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<PackageDTO> Get()
        {
            var data = DataAccessFactory.PackageData().Read();
            var mapped = mapper.Map<List<PackageDTO>>(data);
            return mapped;
        }


        public static PackageDTO GetById(int id)
        {
            var data = DataAccessFactory.PackageData().Read(id);
            var mapped = mapper.Map<PackageDTO>(data);
            return mapped;
        }

        public static PackageDTO Create(PackageDTO packageDTO)
        {
            var package = mapper.Map<Package>(packageDTO);
            var data = DataAccessFactory.PackageData().Create(package);
            return mapper.Map<PackageDTO>(data);
        }

        public static PackageDTO Update(PackageDTO packageDTO)
        {
            var package = mapper.Map<Package>(packageDTO);
            var data = DataAccessFactory.PackageData().Update(package);
            return mapper.Map<PackageDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.PackageData().Delete(id);
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
