using Blog.Identity.Application.DTO;
using Blog.Identity.Domain.Models;

namespace UnitTests
{
    public class MapperTests
    {
        [Fact]
        public void UserToDtoTest()
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Emial = "bob@mail.com",
                FirstName = "Bob",
                SurName = "Bobson",
                Login = "BobMlgPro",
                Password = "B0b$$ecretpa$$w0rd",
                Role = new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    RoleName = "Admin"
                }
            };
            var dto = user.ToDto();
            Assert.NotNull(dto);
            Assert.Equal(user.FirstName, dto.FirstName);
            Assert.Equal(user.SurName, dto.SurName);
            Assert.Equal(user.Login, dto.Login);
            Assert.Equal(user.Emial, dto.Emial);
        }
        [Fact]
        public void DtoToUserTest()
        {
            var dto = new UserDto()
            {
                Emial = "bob@mail.com",
                FirstName = "Bob",
                SurName = "Bobson",
                Login = "BobMlgPro",
                RoleName = "Admin"
            };
            var user = dto.ToBase();
            Assert.NotNull(user);
            Assert.Equal(dto.FirstName, user.FirstName);
            Assert.Equal(dto.SurName, user.SurName);
            Assert.Equal(dto.Login, user.Login);
            Assert.Equal(dto.Emial, user.Emial);
        }
        [Fact]
        public void RoleToDto()
        {
            var role = new Role()
            {
                Id = Guid.NewGuid().ToString(),
                RoleName = "User"
            };
            var dto = role.ToDto();
            Assert.NotNull(dto);
            Assert.Equal(role.RoleName, dto.RoleName);
        }
        [Fact]
        public void DtoToRole()
        {
            var dto = new RoleDto()
            {
                RoleName = "User"
            };
            var role = dto.ToBase();
            Assert.NotNull(role);
            Assert.Equal(dto.RoleName, role.RoleName);
        }
    }
}