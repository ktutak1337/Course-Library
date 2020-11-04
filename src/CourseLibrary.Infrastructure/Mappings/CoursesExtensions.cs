using System.Linq;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Entities;
using CourseLibrary.Core.ValueObjects;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Mappings
{
    public static class CoursesExtensions
    {
        public static CourseDocument AsDocument(this Course course)
            => new CourseDocument
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Category = course.Category,
                Modules = course.Modules.Select(module => new ModuleDocument
                {
                    Id = module.Id,
                    Name = module.Name,
                    Description = module.Description,
                    CreatedAt = module.CreatedAt,
                    Videos = module.Videos.Select(video => new VideoDocument
                    {
                        Id = video.Id,
                        Name = video.Name,
                        VideoUrl = video.VideoUrl,
                        ThumbnailUrl = video.ThumbnailUrl,
                        CreatedAt = video.CreatedAt
                    })
                }),
                Authors = course.Authors.Select(author => new AuthorDocument
                {
                    FullName = author.FullName,
                    Description = author.Description,
                    ImageUrl = author.ImageUrl
                }),
                CreatedAt = course.CreatedAt
            };

        public static Course AsEntity(this CourseDocument document)
            => new Course(
                document.Id,
                document.Name,
                document.Description,
                document.Category,
                document.CreatedAt,
                document.Modules.Select(module => 
                new Module(
                    module.Id, 
                    module.Name,
                    module.Description,
                    module.Videos.Select(video => 
                        new Video(
                            video.Id, 
                            video.Name, 
                            video.VideoUrl, 
                            video.ThumbnailUrl, 
                            video.CreatedAt)),
                    module.CreatedAt)),
                document.Authors.Select(author => 
                    new Author(
                        author.FullName,
                        author.ImageUrl,
                        author.Description)));

        public static CourseDto AsDto(this CourseDocument document)
            => new CourseDto
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                Category = document.Category,
                Modules = document.Modules.Select(module => new ModuleDto
                {
                    Id = module.Id,
                    Name = module.Name,
                    Description = module.Description,
                    CreatedAt = module.CreatedAt,
                    Videos = module.Videos.Select(video => new VideoDto
                    {
                        Id = video.Id,
                        Name = video.Name,
                        VideoUrl = video.VideoUrl,
                        ThumbnailUrl = video.ThumbnailUrl,
                        CreatedAt = video.CreatedAt
                    })
                }),
                Authors = document.Authors.Select(author => new CourseAuthorDto
                {
                    FullName = author.FullName,
                    Description = author.Description,
                    ImageUrl = author.ImageUrl

                }),
                CreatedAt = document.CreatedAt
            };
    }
}
