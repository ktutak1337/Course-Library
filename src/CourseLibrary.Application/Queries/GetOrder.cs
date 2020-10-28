using System;
using CourseLibrary.Application.DTOs;
using Convey.CQRS.Queries;

namespace CourseLibrary.Application.Queries
{
    public class GetOrder : IQuery<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
