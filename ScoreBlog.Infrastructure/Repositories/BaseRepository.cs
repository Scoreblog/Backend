using Microsoft.EntityFrameworkCore;
using ScoreBlog.Domain.Entities;
using ScoreBlog.Domain.Interfaces;
using ScoreBlog.Infrastructure.Data;

namespace ScoreBlog.Infrastructure.Repositories;

internal class BaseRepository<T>(ScoreBlogDbContext context) : IBaseRepository<T>
    where T : Entity
{
    protected readonly ScoreBlogDbContext Context = context;

    public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        entity.UpdatedDate = DateTime.Now;
        entity.CreatedDate = DateTime.Now;
        await Context.AddAsync(entity, cancellationToken);
    }
    
    public virtual void Update(T entity)
    {
        entity.UpdatedDate = DateTime.Now;
        Context.Update(entity);
    }
    
    
    public virtual async Task DeleteAsync(T entity)
    {
        entity.UpdatedDate = DateTime.Now;
        entity.DeletedDate = DateTime.Now;
        await Task.Run(() => Context.Remove(entity));
    }
    
    public virtual async Task<List<T>> GetAll(CancellationToken cancellationToken)
        => await Context.Set<T>().AsNoTracking().ToListAsync(cancellationToken) ??
            throw new Exception("No entities found");
    
    public virtual async Task<T?> GetById(Guid? id, CancellationToken cancellationToken)
     => await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
}