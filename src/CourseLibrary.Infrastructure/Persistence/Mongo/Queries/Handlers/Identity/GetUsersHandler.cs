using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Application.Queries.Identity;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers.Identity
{
    public class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public GetUsersHandler(IMongoRepository<UserDocument, Guid> repository)
            => _repository = repository;

        public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
            => (await _repository.FindAsync(_ => true))
                    .Select(order => order.AsDto());
    }
}