using System;
using System.Collections.Generic;

namespace CourseLibrary.Application.DTOs
{
    public class StudentDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ParticipationInCourseDto> Courses { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
