using System;
using System.Threading.Tasks;
using CourseLibrary.Application.DTOs.Identity;

namespace CourseLibrary.Application.Services
{
    public interface IRefreshTokenService
    {
        Task<string> CreateAsync(Guid userId);
        Task RevokeAsync(string refreshToken);
        Task<AuthDto> RefreshAccessTokenAsync(string refreshToken); 
    }
}
