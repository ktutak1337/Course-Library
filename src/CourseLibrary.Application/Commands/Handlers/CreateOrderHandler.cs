using Convey.CQRS.Commands;
using CourseLibrary.Core.Repositories;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.ValueObjects;
using System.Collections.Generic;
using CourseLibrary.Core.Entities;
using CourseLibrary.Core.Types;
using CourseLibrary.Application.Exceptions;

namespace CourseLibrary.Application.Commands.Handlers
{
    public class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private readonly IOrdersRepository _ordersRepository;

        public CreateOrderHandler(IOrdersRepository ordersRepository) 
            => _ordersRepository = ordersRepository;

        public async Task HandleAsync(CreateOrder command)
        {
            var order = await _ordersRepository.GetAsync(command.Id);
            
            if(!(order is null))
            {
                throw new OrderAlreadyExistsException(command.Id);
            }
           
            var address = new Address("New York", "20 W 34th St", "New York", "United States", "NY 10001");

            var items = new List<OrderItem>() 
            {
                new OrderItem("ice creams", 2, 4.00m),
                new OrderItem("Coffee", 2, 2.99m),
                new OrderItem("Apple pie", 2, 5.49m),
            };

            order = new Order(command.Id, command.BuyerId, address, items, OrderStatus.Pending);

            await _ordersRepository.AddAsync(order);
        }
    }
}
