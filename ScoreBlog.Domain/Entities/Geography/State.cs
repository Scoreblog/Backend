using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Geography;

internal class State : Entity
{
    public UniqueName Name { get; private set; }
    public Country Country { get; private set; }
    public IList<City> Cities { get; private set; }
}