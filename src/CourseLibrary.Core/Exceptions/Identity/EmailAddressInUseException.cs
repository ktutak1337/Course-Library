namespace CourseLibrary.Core.Exceptions.Identity
{
    public class EmailAddressInUseException: DomainException
    {
        public override string Code { get; } = "email_address_in_use";
        public string Email { get; }

        public EmailAddressInUseException(string email) 
            : base($"Email address: '{email}' is already in use.") 
                => Email = email;
    }
}
