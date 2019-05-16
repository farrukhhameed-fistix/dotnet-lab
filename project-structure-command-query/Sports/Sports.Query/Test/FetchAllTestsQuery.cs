using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Query.Test
{
    public class FetchAllTestsQuery : IRequest<IEnumerable<TestViewModel>>
    {
    }
}
