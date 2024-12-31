using Flunt.Notifications;
using Flunt.Br;


namespace ScoreBlog.Domain.Entities;

internal abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; }
    public DateTime UpdatedDate { get;  protected set; }
    public DateTime DeletedDate { get; protected set; }
    
    protected void AddNotificationsFromValueObjects(params List<Notifiable<Notification>> valueObjects)
    {
        foreach (var valueObject in valueObjects)
        {
            AddNotifications(valueObject.Notifications);
        }
    }
}