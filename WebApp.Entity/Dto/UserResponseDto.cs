using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Entity.Dto
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public List<RoleResponseDto> Roles { get; set; } = new ();

    }
    public class RoleResponseDto
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }
}
