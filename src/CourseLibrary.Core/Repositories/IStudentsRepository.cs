using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;

namespace CourseLibrary.Core.Repositories
{
    public interface IStudentsRepository
    {
        Task<Student> GetAsync(Guid id);
        Task<IEnumerable<Student>> BrowseAsync();
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Guid id);
    }
}
