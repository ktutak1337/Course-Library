using System;

namespace CourseLibrary.Application.Commands.WriteModels
{
    public class VideoWriteModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
