using System;

namespace CourseLibrary.Core.Exceptions.Identity
{
    public class RevokedRefreshTokenException : DomainException
    {
        public override string Code { get; } = "revoked_refresh_token";
        public Guid RefreshTokenId { get; }

        public RevokedRefreshTokenException(Guid refreshTokenId) 
            : base($"Revoked refresh token with id: '{refreshTokenId}'.")
                => RefreshTokenId = refreshTokenId;
    }
}
