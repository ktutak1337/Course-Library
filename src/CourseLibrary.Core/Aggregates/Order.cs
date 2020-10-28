using System;
using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Entities;
using CourseLibrary.Core.Events;
using CourseLibrary.Core.Exceptions;
using CourseLibrary.Core.Rules;
using CourseLibrary.Core.Types;
using CourseLibrary.Core.ValueObjects;

namespace CourseLibrary.Core.Aggregates
{
    public class Order : AggregateRoot
    {
        private ISet<OrderItem> _items = new HashSet<OrderItem>();

        public OrderId Id { get; private set; }
        public BuyerId BuyerId { get; private set; }
        public Address Address { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<OrderItem> Items
        {
            get { return _items; }
            private set { _items = new HashSet<OrderItem>(value); }
        }

        private Order() { }

        public Order(OrderId id, BuyerId buyerId, Address address, IEnumerable<OrderItem> orderItems, OrderStatus status, int? version = null)
        {
            Id = id;
            BuyerId = buyerId;
            Address = address;
            Items = orderItems ?? throw new EmptyOrderItemsException(id);
            Status = status;
            TotalPrice = Items.Sum(item => item.Price);
            
            CheckRule(new MinimumAmountOfASingleOrderShouldBeAtLeast10(TotalPrice));
            CheckRule(new AmountOfASingleOrderCannotExceed100k(TotalPrice));

            Version = version ?? 1;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddOrderItem(OrderItem newItem)
        {
            var item = _items.SingleOrDefault(x => x.Id.Equals(newItem.Id));

            if(!(item is null))
            {
                throw new OrderItemAlreadyExistsException(newItem.Id);
            }

            _items.Add(newItem);
            AddDomainEvent(new OrderItemAdded(newItem));
        }

        public void UpdateOrder(Order order)
        {
            BuyerId = order.BuyerId;
            Address = order.Address;
            Status = order.Status;
            TotalPrice = order.TotalPrice;

            AddDomainEvent(new OrderUpdated(order));
        }
    }
}
