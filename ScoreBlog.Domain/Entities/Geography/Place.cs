using Flunt.Notifications;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities;

internal class Place : Entity
{
    public UniqueName Name { get; private set; }
    public Description Description { get; private set; }
    public IList<Picture> Pictures { get; private set; }
    public IList<Property> Properties { get; private set; }
    
    public Place(UniqueName name, Description description, IList<Picture> pictures, IList<Property> properties)
    {
        Name = name;
        Description = description;
        Pictures = pictures;
        Properties = properties;
        
        AddNotificationsFromValueObjects(name, description);
        AddNotificationsFromValueObjects(pictures.Cast<Notifiable<Notification>>().ToList());
        AddNotificationsFromValueObjects(properties.Cast<Notifiable<Notification>>().ToList());
    }
}