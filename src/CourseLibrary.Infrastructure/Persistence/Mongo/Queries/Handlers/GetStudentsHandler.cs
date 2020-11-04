using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetStudentsHandler : IQueryHandler<GetStudents, IEnumerable<StudentDto>>
    {
        private readonly IMongoRepository<StudentDocument, Guid> _repository;

        public GetStudentsHandler(IMongoRepository<StudentDocument, Guid> repository)
            => _repository = repository;

        public async Task<IEnumerable<StudentDto>> HandleAsync(GetStudents query)
            => (await _repository.FindAsync(_ => true))
                .Select(documnet => documnet.AsDto());
    }
}
