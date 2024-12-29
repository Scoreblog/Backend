using Flunt.Notifications;

namespace ScoreBlog.Domain.Entities;

internal abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; }
    public DateTime UpdatedDate { get;  protected set; }
    public DateTime DeletedDate { get; protected set; }
}