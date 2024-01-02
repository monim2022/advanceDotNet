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
    public class ManagerSalaryService
    {
        private static readonly IMapper mapper;

        static ManagerSalaryService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagerSalary, ManagerSalaryDTO>();
                c.CreateMap<ManagerSalaryDTO, ManagerSalary>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<ManagerSalaryDTO> Get()
        {
            var data = DataAccessFactory.ManagerSalaryData().Read();
            var mapped = mapper.Map<List<ManagerSalaryDTO>>(data);
            return mapped;
        }


        public static ManagerSalaryDTO GetById(int id)
        {
            var data = DataAccessFactory.ManagerSalaryData().Read(id);
            var mapped = mapper.Map<ManagerSalaryDTO>(data);
            return mapped;
        }

        public static ManagerSalaryDTO Create(ManagerSalaryDTO managerSalaryDTO)
        {
            var ManagerSalary = mapper.Map<ManagerSalary>(managerSalaryDTO);
            var data = DataAccessFactory.ManagerSalaryData().Create(ManagerSalary);
            return mapper.Map<ManagerSalaryDTO>(data);
        }

        public static ManagerSalaryDTO Update(ManagerSalaryDTO managerSalaryDTO)
        {
            var managerSalary = mapper.Map<ManagerSalary>(managerSalaryDTO);
            var data = DataAccessFactory.ManagerSalaryData().Update(managerSalary);
            return mapper.Map<ManagerSalaryDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.ManagerSalaryData().Delete(id);
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

