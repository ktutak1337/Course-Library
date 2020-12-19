using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Events
{
    public class RefreshTokenRevoked : IDomainEvent
    {
        public RefreshToken RefreshToken { get; }

        public RefreshTokenRevoked(RefreshToken refreshToken) 
            => RefreshToken = refreshToken;
    }
}
