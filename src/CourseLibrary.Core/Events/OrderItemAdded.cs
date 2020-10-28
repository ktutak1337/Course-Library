using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Entities;

namespace CourseLibrary.Core.Events
{
    public class OrderItemAdded : IDomainEvent
    {
        public OrderItem OrderItem { get; }

        public OrderItemAdded(OrderItem orderItem) 
            => OrderItem = orderItem;
    }
}
