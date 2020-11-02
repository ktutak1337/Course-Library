using System;

namespace CourseLibrary.Application.DTOs
{
    public class VideoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
