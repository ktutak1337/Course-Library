using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Repositories;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Repositories.Identity
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public UsersRepository(IMongoRepository<UserDocument, Guid> repository) 
            => _repository = repository;

        public async Task<User> GetAsync(Guid id)
            => (await _repository.GetAsync(id))
                    ?.AsEntity();

        public async Task<User> GetAsync(string email)
            => (await _repository.GetAsync(document => document.Email == email))
                    ?.AsEntity();

        public async Task<bool> ExistsAsync(Guid id)
            => await _repository.ExistsAsync(document => document.Id == id);

        public async Task AddAsync(User user)
            => await _repository.AddAsync(user.AsDocument());

        public async Task UpdateAsync(User user)
            => await _repository.UpdateAsync(user.AsDocument());
    }
}
