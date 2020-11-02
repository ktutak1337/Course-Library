using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Exceptions.ParticipationInCourse;
using CourseLibrary.Core.ValueObjects;

namespace CourseLibrary.Core.Entities
{
    public class ParticipationInCourse : IEntity<ParticipationInCourseId>
    {
        public ParticipationInCourseId Id { get; private set; }
        public CourseId CourseId { get; private set; }
        public Progress Progress { get; private set; }

        public ParticipationInCourse(ParticipationInCourseId id, CourseId courseId, Progress progress)
        {
            Id = id;
            CourseId = courseId;
            Progress = progress ?? throw new EmptyProgressException(id);
        }
    }
}
