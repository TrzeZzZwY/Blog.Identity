using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Infrastructure.CQRS
{
    public interface IQueryDispatcher
    {
        public Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellation = default) where TQuery : IQuery where TResult : IResult;
    }
}
