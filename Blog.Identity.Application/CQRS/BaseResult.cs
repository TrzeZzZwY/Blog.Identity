using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Identity.Application.CQRS
{
    public class BaseResult : IResult
    {
        public bool IsSuccess { get; init; }
        public bool IsFaulted { get; init; }
    }
}
