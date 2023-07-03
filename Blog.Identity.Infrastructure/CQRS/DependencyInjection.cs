using Blog.Identity.Infrastructure.CQRS.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Infrastructure.CQRS
{
    public static class DependencyInjection
    {
        public static void AddCQRS(this IServiceCollection services)
        {
            services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryHandler<GetAllUsersQuery, GetAllUsersQueryResult>, GetAllUsersQueryHandler>();
        }
    }
}
