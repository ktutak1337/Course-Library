using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Category;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Services
{
    public interface ICategoriesService
    {
        Task<CategoryDto> GetAsync(Guid id);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task CreateAsync(CreateCategory command);
        Task UpdateAsync(UpdateCategory command);
        Task DeleteAsync(Guid id);
    }
}
