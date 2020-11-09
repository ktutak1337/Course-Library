using System;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Exceptions.Identity;

namespace CourseLibrary.Core.Aggregates
{
    public class RefreshToken : AggregateRoot
    {
        public RefreshTokenId Id { get; private set; }
        public UserId UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool IsRevoked => RevokedAt.HasValue;
        
        public RefreshToken(RefreshTokenId id, UserId userId, string token, DateTime createdAt, DateTime? revokedAt = null)
        {
            Id = id;
            UserId = userId;

            if (token.IsEmpty())
            {
                throw new EmptyRefreshTokenException(Id);
            }
            
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
        }
        
        public void Revoke(DateTime revokedAt, Guid id)
        {
            if (IsRevoked)
            {
                throw new RevokedRefreshTokenException(id);
            }

            RevokedAt = revokedAt;
        }
    }
}
