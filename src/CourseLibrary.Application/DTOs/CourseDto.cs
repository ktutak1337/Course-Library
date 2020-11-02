using System;
using System.Collections.Generic;

namespace CourseLibrary.Application.DTOs
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<ModuleDto> Modules { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
    }
}
