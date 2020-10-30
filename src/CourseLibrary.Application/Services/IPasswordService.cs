namespace CourseLibrary.Application.Services
{
    public interface IPasswordService
    {
        bool Verify(string hash, string password);
        string HashPassword(string password);  
    }
}
