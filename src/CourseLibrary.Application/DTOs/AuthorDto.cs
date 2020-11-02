using System;

namespace CourseLibrary.Application.DTOs
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
