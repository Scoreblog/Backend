using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Geography;
internal class City : Entity
{
    public UniqueName Name { get; private set; }
    public State State { get; private set; }
    public IList<Place> Places { get; private set; }
}