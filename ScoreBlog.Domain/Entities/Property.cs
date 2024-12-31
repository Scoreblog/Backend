using ScoreBlog.Domain.ValueObjects;
namespace ScoreBlog.Domain.Entities;
internal class Property : Entity
{
    public UniqueName Name { get;  private set; } = null!;
    public string? UrlImageIcon { get; private set; }

    public Property(UniqueName name, string urlImageIcon)
    {
        AddNotificationsFromValueObjects(name);
        if (IsValid)
            Name = name;
        UrlImageIcon = urlImageIcon;
    }
}