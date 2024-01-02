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
    public class ReportServices
    {
        private static readonly IMapper mapper;

        static ReportServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Report, ReportDTO>();
                c.CreateMap<ReportDTO, Report>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<ReportDTO> Get()
        {
            var data = DataAccessFactory.ReportData().Read();
            var mapped = mapper.Map<List<ReportDTO>>(data);
            return mapped;
        }


        public static ReportDTO GetById(int id)
        {
            var data = DataAccessFactory.ReportData().Read(id);
            var mapped = mapper.Map<ReportDTO>(data);
            return mapped;
        }

        public static ReportDTO Create(ReportDTO reportDTO)
        {
            var report = mapper.Map<Report>(reportDTO);
            var data = DataAccessFactory.ReportData().Create(report);
            return mapper.Map<ReportDTO>(data);
        }

        public static ReportDTO Update(ReportDTO reportDTO)
        {
            var report = mapper.Map<Report>(reportDTO);
            var data = DataAccessFactory.ReportData().Update(report);
            return mapper.Map<ReportDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.ReportData().Delete(id);
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
