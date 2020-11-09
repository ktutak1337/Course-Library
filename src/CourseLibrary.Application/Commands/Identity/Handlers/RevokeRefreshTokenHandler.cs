using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Identity.Handlers
{
    public class RevokeRefreshTokenHandler : ICommandHandler<RevokeRefreshToken>
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public RevokeRefreshTokenHandler(IRefreshTokenService refreshTokenService) 
            => _refreshTokenService = refreshTokenService;

        public async Task HandleAsync(RevokeRefreshToken command)
            => await _refreshTokenService.RevokeAsync(command.RefreshToken);
    }
}
