using System;
using System.Collections.Generic;

namespace CourseLibrary.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public string Status { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
