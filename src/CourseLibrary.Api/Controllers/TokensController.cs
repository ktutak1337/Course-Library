using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    public class TokensController : BaseController
    {
        private readonly IRefreshTokenService _refreshTokenService;
        
        public TokensController(IDispatcher dispatcher, IRefreshTokenService refreshTokenService) 
            : base(dispatcher) 
                => _refreshTokenService = refreshTokenService;

        [HttpPost("access-tokens/refresh")]
        public async Task<IActionResult> Post(RefreshAccessToken command)
            => Ok(await _refreshTokenService.RefreshAccessTokenAsync(command.RefreshToken));

        [HttpPost("refresh-tokens/revoke")]
        public async Task<IActionResult> Post(RevokeRefreshToken command)
        {
            await Dispatcher.SendAsync(command);
            
            return NoContent();
        }
        // TODO: Add support for revoke access tokens.
        // [HttpPost("access-tokens/revoke")]
        // public async Task<IActionResult> Post(RevokeAccessToken command)
        // {
        //     await Dispatcher.SendAsync(command);
        //     
        //     return NoContent();
        // }
    }
}
