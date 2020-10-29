namespace CourseLibrary.Application.Services.Identity.Interfaces
{
    public interface IPasswordService
    {
        bool Verify(string hash, string password);
        string HashPassword(string password);  
    }
}
