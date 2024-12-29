using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Blog;

internal class Comment : Entity
{
    public User User { get; private set; }
    public Description Description { get; private set; }
    public IList<Comment>? Answers { get; private set; }
    public IList<Like>? Likes { get; private set; }
}