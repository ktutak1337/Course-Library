using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Mappings
{
    public static class IdentityExtensions
    {
        public static UserDocument AsDocument(this User user)
            => new UserDocument
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
            };

        public static User AsEntity(this UserDocument document)
            => new User(
                document.Id,
                document.Email,
                document.Password,
                document.Role,
                document.CreatedAt,
                document.IsActive);

        public static UserDto AsDto(this UserDocument document)
            => new UserDto
            {
                Id = document.Id,
                Email = document.Email,
                Password = document.Password,
                Role = document.Role,
                IsActive = document.IsActive,
                CreatedAt = document.CreatedAt
            };   
    }
}
