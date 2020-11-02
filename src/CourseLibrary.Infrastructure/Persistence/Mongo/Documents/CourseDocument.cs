using System;
using System.Collections.Generic;
using Convey.Types;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class CourseDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<ModuleDocument> Modules { get; set; }
        public IEnumerable<AuthorDocument> Authors { get; set; }
    }
}
