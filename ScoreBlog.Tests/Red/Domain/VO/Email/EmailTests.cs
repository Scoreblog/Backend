namespace ScoreBlog.Tests.Red.Domain.VO.Email;

public class EmailTests
{
    [Fact]
    public void Email_Should_Be_Invalid_When_Invalid_Email_Provided()
    {
        var email = new ScoreBlog.Domain.ValueObjects.Email("invalid-email");
        Assert.False(email.IsValid); 
        Assert.Contains(email.Notifications, n => n.Message == "Email invalid");
    }
}