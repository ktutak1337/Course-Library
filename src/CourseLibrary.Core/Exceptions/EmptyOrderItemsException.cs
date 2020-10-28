using System;

namespace CourseLibrary.Core.Exceptions
{
    public class EmptyOrderItemsException : DomainException
    {
        public override string Code => "empty_order_items";
        public Guid OrderId { get; }
        
        public EmptyOrderItemsException(Guid orderId) 
            : base($"Empty order items defined for order with ID: {orderId}")
                => OrderId = orderId;
    }
}
