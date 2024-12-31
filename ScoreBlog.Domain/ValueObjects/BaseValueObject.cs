using Flunt.Notifications;

namespace ScoreBlog.Domain.ValueObjects;

internal abstract class BaseValueObject : Notifiable<Notification>
{
    protected string  Key { get; }

    protected BaseValueObject()
    {
        Key = this.GetType().Name;
    }
}