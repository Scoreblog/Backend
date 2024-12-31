using Flunt.Notifications;
using Flunt.Br;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities;

internal abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; protected set; }
    public DateTime CreatedDate { get;  set; }
    public DateTime UpdatedDate { get;  set; }
    public DateTime DeletedDate { get;  set; }
    
    protected void AddNotificationsFromValueObjects(params List<Notifiable<Notification>> valueObjects)
    {
        foreach (var valueObject in valueObjects)
        {
            AddNotifications(valueObject.Notifications);
        }
    }
}