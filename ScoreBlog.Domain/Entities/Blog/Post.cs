using Flunt.Notifications;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Blog;

internal class Post : Entity
{
    public Place Place { get; private set; }
    public Description Legend { get; private set; }
    public IList<Picture> Pictures { get; private set; }
    public IList<Comment> Comments { get; private set; }
    public IList<Reaction> Reactions { get; private set; }
    
    public Post(Place place, Description legend, IList<Picture> pictures, IList<Comment> comments, IList<Reaction> reactions)
    {
        Place = place;
        Legend = legend;
        Pictures = pictures;
        Comments = comments;
        Reactions = reactions;
        AddNotificationsFromValueObjects(place, legend);
        AddNotificationsFromValueObjects(pictures.Cast<Notifiable<Notification>>().ToList());
        AddNotificationsFromValueObjects(comments.Cast<Notifiable<Notification>>().ToList());
        AddNotificationsFromValueObjects(reactions.Cast<Notifiable<Notification>>().ToList());
    }
}