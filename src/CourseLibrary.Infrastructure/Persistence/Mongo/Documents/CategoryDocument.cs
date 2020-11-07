using System;
using Convey.Types;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class CategoryDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
