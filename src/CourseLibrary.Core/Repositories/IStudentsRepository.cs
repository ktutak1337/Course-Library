using System;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;

namespace CourseLibrary.Core.Repositories
{
    public interface IStudentsRepository
    {
        Task<Student> GetAsync(Guid id);
        Task<Student> GetAsync(string email);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Student user);
        Task UpdateAsync(Student user);
        Task DeleteAsync(Guid id);
    }
}
