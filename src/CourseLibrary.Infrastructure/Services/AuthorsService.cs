using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.Commands.Author;
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

        public async Task CreateAsync(CreateAuthor command)
        {
            if(await _repository.ExistsAsync(document => document.Id == command.Id))
            {
                throw new AuthorAlreadyExistsException(command.Id);
            }

            var author = new AuthorDto
            {
                Id = command.Id, 
                FullName = command.FullName, 
                ImageUrl = command.ImageUrl,
                Description = command.Description, 
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(author.AsDocument());
        }

        public async Task UpdateAsync(UpdateAuthor command)
        {
            var author = await _repository.GetAsync(command.Id);
            
            if(author is null)
            {
                throw new AuthorNotFoundException(command.Id);
            }

            author.FullName = command.FullName;
            author.ImageUrl = command.ImageUrl;
            author.Description = command.Description;

            await _repository.UpdateAsync(author);
        }

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
