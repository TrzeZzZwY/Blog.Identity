using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Infrastructure.CQRS
{
    public interface ICommandDispatcher
    {
        public Task<TResult> Dispatch<TCommand, TResult>(TCommand command, CancellationToken cancellation = default) where TCommand : ICommand where TResult : IResult;
    }
}
