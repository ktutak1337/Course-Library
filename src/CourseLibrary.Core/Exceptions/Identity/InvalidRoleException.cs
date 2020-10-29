namespace CourseLibrary.Core.Exceptions.Identity
{
    public class InvalidRoleException : DomainException
    {
        public override string Code { get; } = "invalid_role";
        public string Role { get; } = "invalid_role";
        
        public InvalidRoleException(string role) 
            : base($"Invalid role: {role}.")
                => Role = role;
    }
}
