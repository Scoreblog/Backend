using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Domain.Interfaces;

internal interface IUserRepository : IBaseRepository<User>
{
    Task<bool> Authenticate(User user,CancellationToken cancellationToken);
}