using CourseLibrary.Application.DTOs;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Mappings
{
    public static class AuthorExtensions
    {
        public static AuthorDto AsDto(this AuthorDocument document)
            => new AuthorDto
            {
                Id = document.Id,
                FullName = document.FullName,
                ImageUrl = document.ImageUrl,
                Description = document.Description,
                CreatedAt = document.CreatedAt
            };

        public static AuthorDocument AsDocument(this AuthorDto dto)
            => new AuthorDocument
            {
                Id = dto.Id,
                FullName = dto.FullName,
                ImageUrl = dto.ImageUrl,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt
            };
    }
}
