using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class ParticipationInCourseId : TypedIdValueBase
    {
        public ParticipationInCourseId(Guid value) 
            : base(value) { }

        public static implicit operator ParticipationInCourseId(Guid participationInCourseId)
            => new ParticipationInCourseId(participationInCourseId);
    }
}
