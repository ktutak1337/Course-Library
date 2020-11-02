using System;
using System.Collections.Generic;

namespace CourseLibrary.Application.DTOs
{
    public class ModuleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<VideoDto> Videos { get; set; }
    }
}
