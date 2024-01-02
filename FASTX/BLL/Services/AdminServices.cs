﻿using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminServices
    {

           

        public static void CreateSalary(ManagerSalaryDTO managerSalaryDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagerSalaryDTO, ManagerSalary >();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ManagerSalary>( managerSalaryDTO);
            DataAccessFactory.ManagersalData().Create(mapped);
        }

        public static List<ManagerSalaryDTO> GetAllSalary()
        {
            var data = DataAccessFactory.ManagersalData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ManagerSalary, ManagerSalaryDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<ManagerSalaryDTO>>(data);
            return ret;
        }

        public static void CreateReport(ReportDTO ReportDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReportDTO, Report>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ManagerSalary>(ReportDTO);
            DataAccessFactory.ManagersalData().Create(mapped);
        }


        public static List<ReportDTO> GetAllReport()
        {
            var data = DataAccessFactory.ReportData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Report, ReportDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<ReportDTO>>(data);
            return ret;
        }














    }
}
