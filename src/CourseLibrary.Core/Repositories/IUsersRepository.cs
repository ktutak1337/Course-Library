using System;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;

namespace CourseLibrary.Core.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
