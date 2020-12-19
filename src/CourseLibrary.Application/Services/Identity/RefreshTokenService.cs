using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Exceptions.Identity;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Services.Identity
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IUsersService _usersService;
        private readonly IJwtBroker _jwtBroker;
        
        public RefreshTokenService(IRefreshTokensRepository refreshTokensRepository, IUsersService usersService, IJwtBroker jwtBroker)
        {
            _refreshTokensRepository = refreshTokensRepository;
            _usersService = usersService;
            _jwtBroker = jwtBroker;
        }
        
        public async Task<string> CreateAsync(Guid userId)
        {
            var token = GenerateRefreshToken();
            var refreshToken = new RefreshToken(Guid.NewGuid(), userId, token, DateTime.UtcNow);
            await _refreshTokensRepository.AddAsync(refreshToken);

            return token;
        }

        public async Task RevokeAsync(string refreshToken)
        {
            var token = await _refreshTokensRepository.GetAsync(refreshToken);
            
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            token.Revoke(DateTime.UtcNow, token.Id);
            await _refreshTokensRepository.UpdateAsync(token);
        }

        public async Task<AuthDto> RefreshAccessTokenAsync(string refreshToken)
        {
            var token = await _refreshTokensRepository.GetAsync(refreshToken);
            
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            if (token.IsRevoked)
            {
                throw new RevokedRefreshTokenException(token.Id);
            }

            var user = await _usersService.GetAsync(token.UserId);
            
            if (user is null)
            {
                throw new UserNotFoundException(token.UserId);
            }
            
            var auth = _jwtBroker.CreateToken(token.UserId, user.Role);
            auth.RefreshToken = refreshToken;

            return auth;
        }
        
        private string GenerateRefreshToken(int length = 30)
        {
            var randomNumber = new byte[length];
            
            using var randomNumberGenerator = RandomNumberGenerator.Create();			
            randomNumberGenerator.GetBytes(randomNumber);
            var result = Convert.ToBase64String(randomNumber);
            
            return Regex.Replace(result, @"[^0-9a-zA-Z]+", string.Empty);
        }
    }
}
