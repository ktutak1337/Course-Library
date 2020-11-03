using System;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetCourseHandler : IQueryHandler<GetCourse, CourseDto>
    {
        private readonly IMongoRepository<CourseDocument, Guid> _repository;

        public GetCourseHandler(IMongoRepository<CourseDocument, Guid> repository)
            => _repository = repository;

        public async Task<CourseDto> HandleAsync(GetCourse query)
            => (await _repository.GetAsync(x => x.Id == query.Id))
                ?.AsDto();
    }
}
