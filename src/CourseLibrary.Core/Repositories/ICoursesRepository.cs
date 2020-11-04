using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;

namespace CourseLibrary.Core.Repositories
{
    public interface ICoursesRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<IEnumerable<Course>> BrowseAsync();
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Guid id);
    }
}
