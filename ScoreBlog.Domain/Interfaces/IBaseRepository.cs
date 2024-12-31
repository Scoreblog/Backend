using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Domain.Interfaces;

internal interface IBaseRepository<T> where T : Entity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    void Update(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
    Task<T?> GetById(Guid? id, CancellationToken cancellationToken);
}