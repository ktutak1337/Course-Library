using System;
using System.Collections.Generic;
using Convey.Types;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents
{
    public class StudentDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ParticipationInCourseDocument> Courses { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
