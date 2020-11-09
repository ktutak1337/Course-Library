using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Repositories;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Repositories.Identity
{
    public class RefreshTokensRepository : IRefreshTokensRepository
    {
        private readonly IMongoRepository<RefreshTokenDocument, Guid> _repository;

        public RefreshTokensRepository(IMongoRepository<RefreshTokenDocument, Guid> repository) 
            => _repository = repository;

        public async Task<RefreshToken> GetAsync(string token)
            => (await _repository.GetAsync(x => x.Token == token))
                ?.AsEntity();

        public async Task AddAsync(RefreshToken token)
            => await _repository.AddAsync(token.AsDocument());

        public async Task UpdateAsync(RefreshToken token)
            => await _repository.UpdateAsync(token.AsDocument());
    }
}
