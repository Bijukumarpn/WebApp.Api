using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Entity.Dto
{
    public class Errors
    {
        public int Id { get; set; }      
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
