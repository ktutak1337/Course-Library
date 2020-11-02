using System;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class VideoDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
