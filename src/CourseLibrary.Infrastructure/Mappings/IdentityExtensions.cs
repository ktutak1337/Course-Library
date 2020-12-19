using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Mappings
{
    public static class IdentityExtensions
    {
        public static UserDocument AsDocument(this UserDto user)
            => new UserDocument
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
            };

        public static UserDto AsDto(this UserDocument document)
            => new UserDto
            {
                Id = document.Id,
                FirstName = document.FirstName,
                LastName = document.LastName,
                Email = document.Email,
                Password = document.Password,
                Role = document.Role,
                IsActive = document.IsActive,
                CreatedAt = document.CreatedAt
            };
        
        public static RefreshToken AsEntity(this RefreshTokenDocument document)
            => new RefreshToken(document.Id, document.UserId, document.Token, document.CreatedAt, document.RevokedAt);
        
        public static RefreshTokenDocument AsDocument(this RefreshToken refreshToken)
            => new RefreshTokenDocument
            {
                Id = refreshToken.Id,
                UserId = refreshToken.UserId,
                Token = refreshToken.Token,
                CreatedAt = refreshToken.CreatedAt,
                RevokedAt = refreshToken.RevokedAt
            };
    }
}
