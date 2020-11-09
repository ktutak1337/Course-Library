using System;

namespace CourseLibrary.Core.Exceptions.Identity
{
    public class EmptyRefreshTokenException : DomainException
    {
        public override string Code { get; } = "empty_refresh_token";
        public Guid RefreshTokenId { get; }

        public EmptyRefreshTokenException(Guid refreshTokenId) 
            : base($"Empty token defined for the refresh token with id: '{refreshTokenId}'.")
                => RefreshTokenId = refreshTokenId;
    }
}
