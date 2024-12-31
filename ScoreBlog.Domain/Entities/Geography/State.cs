using Flunt.Br;
using Flunt.Notifications;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Geography;

internal class State : Entity
{
    public UniqueName Name { get; private set; }
    public Country Country { get; private set; }
    public IList<City> Cities { get; private set; } 
    
    public State(UniqueName name, Country country, IList<City> cities)
    {
        Name = name;
        Country = country;
        Cities = cities;
        AddNotificationsFromValueObjects(name, country);
        AddNotificationsFromValueObjects(cities.Cast<Notifiable<Notification>>().ToList());
    }
}