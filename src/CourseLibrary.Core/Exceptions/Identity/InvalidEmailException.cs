namespace CourseLibrary.Core.Exceptions.Identity
{
    public class InvalidEmailException : DomainException
    {
        public override string Code { get; } = "invalid_email";
        public string Email { get; }
        
        public InvalidEmailException(string email) 
            : base($"Invalid email: {email}.")
                => Email = email;
    }
}
