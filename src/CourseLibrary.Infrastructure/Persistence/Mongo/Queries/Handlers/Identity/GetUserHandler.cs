using System;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Application.Queries.Identity;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers.Identity
{
    public class GetUserHandler : IQueryHandler<GetUser, UserDto>
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public GetUserHandler(IMongoRepository<UserDocument, Guid> repository)
            => _repository = repository;

        public async Task<UserDto> HandleAsync(GetUser query)
            => (await _repository.GetAsync(x => x.Id == query.Id))
                ?.AsDto();
    }
}
