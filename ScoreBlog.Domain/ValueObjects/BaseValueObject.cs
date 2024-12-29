using Flunt.Notifications;

namespace ScoreBlog.Domain.ValueObjects;

internal class BaseValueObject : Notifiable<Notification>
{
    protected string  Key { get; }
    
    public BaseValueObject()
    {
        Key = this.GetType().Name;
    }
}