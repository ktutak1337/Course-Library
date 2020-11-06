using CourseLibrary.Application.DTOs;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Mappings
{
    public static class CategoryExtensions
    {
        public static CategoryDto AsDto(this CategoryDocument document)
            => new CategoryDto
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                CreatedAt = document.CreatedAt
            };

        public static CategoryDocument AsDocument(this CategoryDto dto)
            => new CategoryDocument
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt
            };
    }
}
