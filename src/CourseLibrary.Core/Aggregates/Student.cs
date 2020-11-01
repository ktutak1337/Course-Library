using System.Collections.Generic;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Entities;

namespace CourseLibrary.Core.Aggregates
{
    public class Student : AggregateRoot
    {
        private ISet<ParticipationInCourse> _courses = new HashSet<ParticipationInCourse>();

        public StudentId Id { get; private set; }
        public UserId UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public IEnumerable<ParticipationInCourse> Courses
        {
            get { return _courses; }
            private set { _courses = new HashSet<ParticipationInCourse>(value); }
        }
    }
}
