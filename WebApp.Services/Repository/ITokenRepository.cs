using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entity.Dto;

namespace WebApp.Services.Repository
{
    public interface ITokenRepository
    {
        public  Task<string> GenerateToken(UserInfoRequest userInfo);
    }
}
