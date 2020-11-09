using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class RefreshTokenId : TypedIdValueBase
    {
        public RefreshTokenId(Guid value) 
            : base(value) { }

        public static implicit operator RefreshTokenId(Guid refreshTokenId)
            => new RefreshTokenId(refreshTokenId);
    }
}
