using Blog.Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Application.DTO
{
    public static class Mapper
    {
        public static User ToBase(this UserDto x)
        {
            return new User()
            {
                FirstName = x.FirstName,
                Login = x.Login,
                SurName = x.SurName,
                Emial = x.Emial
            };
        }
        public static IEnumerable<User> ToBase(this IEnumerable<UserDto> x)
        {
            foreach (var i in x) yield return i.ToBase();
        }
        public static UserDto ToDto(this User x)
        {
            return new UserDto()
            {
                Emial = x.Emial,
                FirstName = x.FirstName,
                Login = x.Login,
                RoleName = x.FirstName,
                SurName = x.FirstName
            };
        }
        public static IEnumerable<UserDto> ToDto(this IEnumerable<User> x)
        {
            foreach (var i in x) yield return i.ToDto();
        }
        public static Role ToBase(this RoleDto x)
        {
            return new Role()
            {
                RoleName = x.RoleName
            };
        }
        public static IEnumerable<Role> ToBase(this IEnumerable<RoleDto> x)
        {
            foreach (var i in x) yield return i.ToBase();
        }
        public static RoleDto ToDto(this Role x)
        {
            return new RoleDto()
            {
                RoleName = x.RoleName
            };
        }
        public static IEnumerable<RoleDto> ToBase(this IEnumerable<Role> x)
        {
            foreach (var i in x) yield return i.ToDto();
        }
    }
}
