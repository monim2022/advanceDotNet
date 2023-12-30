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
    public class BranchServices
    {
        public static List<BranchDTO> Get()
        {
            var data = DataAccessFactory.BranchData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Branch,BranchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BranchDTO>>(data);
            return mapped;
        }
        public static BranchDTO Get(string BranchName)
        {
            var data = DataAccessFactory.BranchData().Read(BranchName);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Branch,BranchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BranchDTO>(data);
            return mapped;

        }
    }
}
