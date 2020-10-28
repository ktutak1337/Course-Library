using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Repositories;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;
using Convey.Persistence.MongoDB;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Repositories
{
    public sealed class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoRepository<OrderDocument, Guid> _repository;

        public OrdersRepository(IMongoRepository<OrderDocument, Guid> repository) 
            => _repository = repository;

        public async Task<Order> GetAsync(Guid id)
            => (await _repository.GetAsync(id))
                ?.AsEntity();

        public async Task<IEnumerable<Order>> BrowseAsync()
            => (await _repository.FindAsync(_ => true))
                ?.Select(order => order.AsEntity());

        public async Task AddAsync(Order order) 
            => await _repository.AddAsync(order.AsDocument());

        public async Task UpdateAsync(Order order)
            => await _repository.UpdateAsync(order.AsDocument());

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
