using System;

namespace CourseLibrary.Application.DTOs
{
    public class ParticipationInCourseDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public ProgressDto Progress { get; set; }
    }
}
