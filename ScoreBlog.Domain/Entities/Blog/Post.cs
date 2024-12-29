using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Blog;

internal class Post : Entity
{
    public Place Place { get; private set; }
    public Description Legend { get; private set; }
    public IList<Picture> Pictures { get; private set; }
    public IList<Comment> Comments { get; private set; }
    public IList<Reaction> Reactions { get; private set; }
}