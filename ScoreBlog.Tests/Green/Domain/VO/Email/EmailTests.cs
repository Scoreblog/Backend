namespace ScoreBlog.Tests.Green.Domain.VO.Email;

public class EmailTests
{
    [Fact]
    public void Email_Should_Be_Valid_When_Valid_Email_Provided()
    {
        var email = new ScoreBlog.Domain.ValueObjects.Email("test@example.com");
        Assert.True(email.IsValid); 
    }
}