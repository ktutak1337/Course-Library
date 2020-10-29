using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value) 
            : base(value) { }

        public static implicit operator UserId(Guid userId)
            => new UserId(userId);
    }
}
