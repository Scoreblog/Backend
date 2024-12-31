using Flunt.Notifications;
using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities.Blog;

internal class Comment : Entity
{
    public User User { get; private set; }
    public Description Description { get; private set; }
    public IList<Comment>? Answers { get; private set; }
    public IList<Like>? Likes { get; private set; }
    
    public Comment(User user, Description description, IList<Comment>? answers, IList<Like>? likes)
    {
        User = user;
        Description = description;
        Answers = answers;
        Likes = likes;
        
        AddNotificationsFromValueObjects(user, description);
        AddNotificationsFromValueObjects(answers!.Cast<Notifiable<Notification>>().ToList());
        AddNotificationsFromValueObjects(likes!.Cast<Notifiable<Notification>>().ToList());
    }
}