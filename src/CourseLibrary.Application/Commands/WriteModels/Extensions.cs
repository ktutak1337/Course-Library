using System;
using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Core.Entities;

namespace CourseLibrary.Application.Commands.WriteModels
{
    public static class Extensions
    {
        public static IEnumerable<Module> AsEntities(this IEnumerable<ModuleWriteModel> courseWriteModel)
            => courseWriteModel.Select(module => 
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
                        module.CreatedAt));

        public static IEnumerable<Core.ValueObjects.Author> AsEntities(this IEnumerable<AuthorWriteModel> courseWriteModel)
            => courseWriteModel.Select(author => 
                    new Core.ValueObjects.Author(
                        author.FullName,
                        author.ImageUrl,
                        author.Description));
    }
}
