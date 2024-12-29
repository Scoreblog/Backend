namespace ScoreBlog.Domain.Entities.Blog;

internal class Reaction : Entity
{
    public Comment Comment { get; private set; }
    public string? UrlImageIcon { get; private set; }
}