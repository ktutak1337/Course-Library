using System.Threading.Tasks;
using CourseLibrary.Core.Aggregates;

namespace CourseLibrary.Core.Repositories
{
    public interface IRefreshTokensRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}
