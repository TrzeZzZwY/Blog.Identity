using Blog.Identity.Application.CQRS;
using Blog.Identity.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Blog.Identity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll(
            [FromQuery] string? roleName,
            [FromQuery] string? firstName,
            [FromQuery] string? surName,
            [FromQuery] int page,
            [FromQuery] int pageSize
            )
        {
            GetAllUsersQuery query = new GetAllUsersQuery()
            {
                FirstName = firstName,
                SurName = surName,
                role = roleName,
                Page = page,
                PageSize = pageSize
            };

            var result = await _queryDispatcher.Dispatch<GetAllUsersQuery, GetAllUsersQueryResult>(query, default);

            if (result.IsFaulted == true) return BadRequest();

            return Ok(result.users);
        }
    }
}
