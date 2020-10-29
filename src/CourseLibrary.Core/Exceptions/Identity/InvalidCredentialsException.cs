namespace CourseLibrary.Core.Exceptions.Identity
{
    public class InvalidCredentialsException : DomainException
    {
        public override string Code { get; } = "invalid_credentials";
        public InvalidCredentialsException() 
            : base("Invalid credentials entered.") { }
    }
}
