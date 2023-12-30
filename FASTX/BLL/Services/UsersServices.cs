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
    public class UsersServices
    {
        public static List<UsersDTO> Get()
        {
            var data = DataAccessFactory.UsersData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Users, UsersDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UsersDTO>>(data);
            return mapped;
        }
        public static UsersDTO Get(int UsersId)
        {
            var data = DataAccessFactory.UsersData().Read(UsersId);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Users, UsersDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UsersDTO>(data);
            return mapped;

        }
    }
}
