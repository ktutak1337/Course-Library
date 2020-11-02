using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Author;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Services
{
    public interface IAuthorsService
    {
        Task<AuthorDto> GetAsync(Guid id);
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
        Task CreateAsync(CreateAuthor command);
        Task UpdateAsync(UpdateAuthor command);
        Task DeleteAsync(Guid id);
    }
}
