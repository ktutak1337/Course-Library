using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;

namespace CourseLibrary.Core.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetAsync(Guid id);
        Task<IEnumerable<Order>> BrowseAsync();
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
    }
}
