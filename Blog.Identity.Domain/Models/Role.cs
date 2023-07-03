using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Domain.Models
{
    public class Role : BaseModel
    {
        public string RoleName { get; set; }
    }
    public enum Roles
    {
        Admin = 0,
        User = 1
    }
}
