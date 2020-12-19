using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.DTOs.Identity;

namespace CourseLibrary.Application.Services
{
    public interface IUsersService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task CreateAsync(SignUp command);
        Task UpdateAsync(UpdateUser command);
        Task UpdateAsync(UserDto user);
        Task DeleteAsync(Guid id);
    }
}
