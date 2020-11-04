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
    public class GetStudentHandler: IQueryHandler<GetStudent, StudentDto>
    {
        private readonly IMongoRepository<StudentDocument, Guid> _repository;

        public GetStudentHandler(IMongoRepository<StudentDocument, Guid> repository)
            => _repository = repository;

        public async Task<StudentDto> HandleAsync(GetStudent query)
            => (await _repository.GetAsync(x => x.Id == query.UserId))
                ?.AsDto();
    }
}
