using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Application.DTO
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Emial { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string RoleName { get; set; }
    }
}
