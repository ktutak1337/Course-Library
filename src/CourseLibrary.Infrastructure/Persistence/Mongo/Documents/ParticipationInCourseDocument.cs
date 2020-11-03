using System;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class ParticipationInCourseDocument
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public ProgressDocument Progress { get; set; }
    }
}
