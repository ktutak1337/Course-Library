using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Services;
using CourseLibrary.Infrastructure.Exceptions;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IMongoRepository<AuthorDocument, Guid> _repository;

        public AuthorsService(IMongoRepository<AuthorDocument, Guid> repository) 
            => _repository = repository;

        public async Task<AuthorDto> GetAsync(Guid id)
            => (await _repository.GetAsync(id))
                ?.AsDto();

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
            => (await _repository.FindAsync(_ => true))
                ?.Select(order => order.AsDto());

        public async Task CreateAsync(AuthorDto author)
        {
            if(await _repository.ExistsAsync(document => document.Id == author.Id))
            {
                throw new AuthorAlreadyExistsException(author.Id);
            }

            await _repository.AddAsync(author.AsDocument());
        }

        public async Task UpdateAsync(AuthorDto author)
            => await _repository.UpdateAsync(author.AsDocument());

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
