using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Infrastructure.CQRS
{
    public interface IResult
    {
        public bool IsSuccess { get; init; }
        public bool IsFaulted { get; init; }
    }
}
