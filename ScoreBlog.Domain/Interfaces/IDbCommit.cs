namespace ScoreBlog.Domain.Interfaces;

internal interface IDbCommit
{
    Task Commit(CancellationToken cancellationToken);
}