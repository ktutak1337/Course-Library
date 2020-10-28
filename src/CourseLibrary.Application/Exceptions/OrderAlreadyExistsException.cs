using System;

namespace CourseLibrary.Application.Exceptions
{
    public class OrderAlreadyExistsException : ApplicationException
    {
        public override string Code => "order_already_exists";
        public Guid OrderId { get; }

        public OrderAlreadyExistsException(Guid orderId) 
            : base($"Order with Id: {orderId} already exists.")
                => OrderId = orderId;
    }
}
