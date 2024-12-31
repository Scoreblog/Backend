using Microsoft.EntityFrameworkCore;
using ScoreBlog.Domain.Entities;
using ScoreBlog.Domain.Interfaces;
using ScoreBlog.Infrastructure.Data;

namespace ScoreBlog.Infrastructure.Repositories;

internal class UserRepository(ScoreBlogDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<bool> Authenticate(User user, CancellationToken cancellationToken)
    {
        var userFromDb = await context.Set<User>().AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Address == user.Email.Address && u.Active, cancellationToken);
        
        return userFromDb!.Password.VerifyPassword(user.Password);
    }
}