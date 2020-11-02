using System;
using Convey.Types;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class AuthorDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
