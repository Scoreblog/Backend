using Flunt.Notifications;
using Flunt.Validations;
using ScoreBlog.Domain.Enums;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Geography;

internal class Country : Entity
{
    public UniqueName Name { get; private set; }
    public EContinent Continent { get; private set; }
    public IList<State> States { get; private set ; }

    public Country(UniqueName name, EContinent continent, IList<State> states)
    {
        Name = name;
        Continent = continent;
        States = states;
        AddNotificationsFromValueObjects(name);
        AddNotificationsFromValueObjects(states.Cast<Notifiable<Notification>>().ToList());
    }
}