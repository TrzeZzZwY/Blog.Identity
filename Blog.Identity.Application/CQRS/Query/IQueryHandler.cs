using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Application.CQRS
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery where TResult : IResult
    {
        public Task<TResult> HandleAsync(TQuery query, CancellationToken cancellation = default);
    }
}
