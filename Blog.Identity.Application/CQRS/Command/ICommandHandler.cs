using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Application.CQRS
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand where TResult : IResult
    {
        public Task<TResult> HandleAsync(TCommand commend, CancellationToken cancellation = default);
    }
}
