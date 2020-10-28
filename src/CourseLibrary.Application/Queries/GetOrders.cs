using System.Collections.Generic;
using CourseLibrary.Application.DTOs;
using Convey.CQRS.Queries;

namespace CourseLibrary.Application.Queries
{
    public class GetOrders : IQuery<IEnumerable<OrderDto>> { }
}
