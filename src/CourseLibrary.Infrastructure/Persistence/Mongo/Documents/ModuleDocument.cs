using System;
using System.Collections.Generic;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class ModuleDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<VideoDocument> Videos { get; set; }
    }
}
