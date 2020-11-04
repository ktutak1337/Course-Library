using System;
using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Entities;
using CourseLibrary.Core.Exceptions.Student;

namespace CourseLibrary.Core.Aggregates
{
    public class Student : AggregateRoot
    {
        private ISet<ParticipationInCourse> _courses = new HashSet<ParticipationInCourse>();

        public UserId UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<ParticipationInCourse> Courses
        {
            get { return _courses; }
            private set { _courses = new HashSet<ParticipationInCourse>(value); }
        }

        private Student() { }

        public Student(UserId userId, string firstName, string lastName, DateTime createdAt, 
            IEnumerable<ParticipationInCourse> courses = null)
        {
            UserId = userId;

            if(firstName.IsEmpty())
            {
                throw new EmptyStudentFirstNameException(userId);
            }

            FirstName = firstName;

            if(lastName.IsEmpty())
            {
                throw new EmptyStudentLastNameException(userId);
            }

            LastName = lastName;
            CreatedAt = createdAt;
            Courses = courses ?? Enumerable.Empty<ParticipationInCourse>();
        }
    }
}
