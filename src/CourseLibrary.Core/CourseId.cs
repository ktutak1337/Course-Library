using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class CourseId: TypedIdValueBase
    {
        public CourseId(Guid value) 
            : base(value) { }

        public static implicit operator CourseId(Guid courseId)
            => new CourseId(courseId);
    }
}
