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
    public class AuthService
    {
        private static readonly IMapper mapper;

        static AuthService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenDTO>();
                c.CreateMap<TokenDTO, Token>();
            });
            mapper = cfg.CreateMapper();
        }

        public static TokenDTO Login(string email, string password)
        {
            var customer = DataAccessFactory.AuthData().Authenticate(email, password);
            if (customer != null)
            {
                var token = new Token();
                token.TokenKey = Guid.NewGuid().ToString();
                token.CustomerId = customer.CustomerId;
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccessFactory.TokenData().Create(token);
                
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccessFactory.TokenData().Read()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }
    }
}
