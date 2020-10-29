using System;
using Convey.Types;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity
{
    public class UserDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }   
    }
}
