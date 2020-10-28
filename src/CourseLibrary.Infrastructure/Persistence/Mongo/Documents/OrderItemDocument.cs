using System;
using Convey.Types;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class OrderItemDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
    }
}
