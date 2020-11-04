using System.Linq;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Entities;
using CourseLibrary.Core.ValueObjects;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Mappings
{
    public static class StudentExtensions
    {
        public static StudentDocument AsDocument(this Student student)
            => new StudentDocument
            {
                UserId = student.UserId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Courses = student.Courses.Select(course => new ParticipationInCourseDocument
                {
                    Id = course.Id,
                    CourseId = course.CourseId,
                    Progress = new ProgressDocument
                    {
                        Value = course.Progress.Value
                    }
                }),
                CreatedAt = student.CreatedAt
            };

        public static Student AsEntity(this StudentDocument document)
            => new Student(
                document.UserId,
                document.FirstName,
                document.LastName,
                document.CreatedAt,
                document.Courses.Select(course => 
                new ParticipationInCourse(
                    course.Id, 
                    course.CourseId,
                    new Progress(course.Progress.Value))));

        public static StudentDto AsDto(this StudentDocument document)
            => new StudentDto
            {
                UserId = document.UserId,
                FirstName = document.FirstName,
                LastName = document.LastName,
                Courses = document.Courses.Select(course => new ParticipationInCourseDto
                {
                    Id = course.Id,
                    CourseId = course.CourseId,
                    Progress = new ProgressDto
                    {
                        Value = course.Progress.Value
                    }
                }),
                CreatedAt = document.CreatedAt
            };
    }
}
