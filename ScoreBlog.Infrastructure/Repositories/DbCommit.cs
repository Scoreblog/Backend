using ScoreBlog.Domain.Interfaces;
using ScoreBlog.Infrastructure.Data;

namespace ScoreBlog.Infrastructure.Repositories;

internal class DbCommit(ScoreBlogDbContext context) : IDbCommit
{
    public async Task Commit(CancellationToken cancellationToken)
        => await context.SaveChangesAsync(cancellationToken);
}