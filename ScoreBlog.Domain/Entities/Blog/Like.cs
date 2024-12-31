namespace ScoreBlog.Domain.Entities.Blog;
internal class Like : Entity
{
    public Comment Comment { get; private set; }
    public string? UrlImageIcon { get; private set; }

    public Like(Comment comment, string urlImageIcon)
    {
        Comment = comment;
        UrlImageIcon = urlImageIcon;
        AddNotificationsFromValueObjects(comment);
    }
}