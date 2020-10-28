using System;
using System.Collections.Generic;
using CourseLibrary.Application.Commands.WriteModels;
using CourseLibrary.Core;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands
{
    public class CreateOrder : ICommand
    {
        public Guid Id { get; set; } = new OrderId(Guid.NewGuid());
        public Guid BuyerId { get; set; }
        public AddressWriteModel Address { get; set; }
        public IEnumerable<OrderItemWriteModel> Items { get; set; }
    }
}
