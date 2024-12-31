using Flunt.Notifications;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Geography;
internal class City : Entity
{
    public UniqueName Name { get; private set; }
    public State State { get; private set; }
    public IList<Place> Places { get; private set; }

    public City(UniqueName name, State state, IList<Place> places)
    {
        Name = name;
        State = state;
        Places = places;
        AddNotificationsFromValueObjects(name, state);
        AddNotificationsFromValueObjects(places.Cast<Notifiable<Notification>>().ToList());
    }
}