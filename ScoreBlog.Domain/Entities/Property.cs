using ScoreBlog.Domain.ValueObjects;
namespace ScoreBlog.Domain.Entities;
internal class Property : Entity
{
    public UniqueName Name { get;  set; }
    public string? UrlImageIcon { get; set; }
}