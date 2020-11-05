using Microsoft.AspNetCore.Authorization;

namespace CourseLibrary.Application.Services.Identity
{
    public class AllowAttribute : AuthorizeAttribute
    {
        public AllowAttribute(params string[] roles) 
            => Roles = string.Join(",", roles);
    }
}
