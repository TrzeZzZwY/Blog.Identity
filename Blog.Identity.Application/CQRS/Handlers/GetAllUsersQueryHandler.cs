using Blog.Identity.Application.CQRS;
using Blog.Identity.Domain.Models;
using Blog.Identity.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Application.CQRS
{
    public class GetAllUsersQuery : IQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? role { get; set; }
        public string? FirstName { get; set; }
        public string? SurName { get; set; }
    }
    public class GetAllUsersQueryResult : BaseResult
    {
        public int TotalPages { get; set; }
        public int TotalResult { get; set; }
        public List<User>? users { get; set; }
    }
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, GetAllUsersQueryResult>
    {
        private readonly AppDbContext _context;

        public GetAllUsersQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllUsersQueryResult> HandleAsync(GetAllUsersQuery query, CancellationToken cancellation = default)
        {
            try
            {
                var result = _context.Users.Include(e => e.Role).AsQueryable();
                List<User> users = new List<User>();
                if (query.role is not null)
                {
                    result = result.Where(e => e.Role.RoleName == query.role);
                }
                if (query.FirstName is not null)
                {
                    result = result.Where(e => e.FirstName.Contains(query.FirstName));
                }
                if (query.SurName is not null)
                {
                    result = result.Where(e => e.FirstName.Contains(query.SurName));
                }
                if (query.Page == 0 && query.PageSize == 0)
                {
                    users = await result.ToListAsync();
                    return new GetAllUsersQueryResult()
                    {
                        IsSuccess = true,
                        IsFaulted = false,
                        TotalPages = 0,
                        TotalResult = users.Count,
                        users = users
                    };
                }
                if (query.Page <= 0) throw new ArgumentException($"The argument {nameof(query.Page)} must be grater than 0");
                if (query.PageSize <= 0) throw new ArgumentException($"The argument {nameof(query.PageSize)} must be grater than 0");

                int totalResult = result.Count();
                int totalPages = (int)Math.Ceiling((decimal)totalResult / query.PageSize);
                result = result.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
                users = await result.ToListAsync();

                return new GetAllUsersQueryResult()
                {
                    IsSuccess = true,
                    IsFaulted = false,
                    TotalPages = totalPages,
                    TotalResult = totalResult,
                    users = users
                };
            }
            catch (Exception e)
            {
                return new GetAllUsersQueryResult()
                {
                    IsFaulted = true,
                    IsSuccess = false,
                    TotalPages = 0,
                    TotalResult = 0,
                    users = null
                };
            }

        }
    }
}
