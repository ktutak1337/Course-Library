using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Services
{
    public interface IAuthorsService
    {
        Task<AuthorDto> GetAsync(Guid id);
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
        Task CreateAsync(AuthorDto author);
        Task UpdateAsync(AuthorDto author);
        Task DeleteAsync(Guid id);
    }
}
