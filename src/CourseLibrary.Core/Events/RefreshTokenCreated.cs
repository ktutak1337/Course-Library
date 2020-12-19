using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Events
{
    public class RefreshTokenCreated : IDomainEvent
    {
        public RefreshToken RefreshToken { get; }

        public RefreshTokenCreated(RefreshToken refreshToken) 
            => RefreshToken = refreshToken;
    }
}
