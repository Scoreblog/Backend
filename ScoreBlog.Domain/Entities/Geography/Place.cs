using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities;

internal class Place : Entity
{
    public UniqueName Name { get; private set; }
    public Description Description { get; private set; }
    public IList<Picture> Pictures { get; private set; }
    public IList<Property> Properties { get; private set; }
}