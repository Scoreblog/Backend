namespace ScoreBlog.Tests.Red.Domain.VO.Description;

public class DescriptionTests
{
    [Fact]
    public void Description_Should_Be_Invalid_When_Invalid_Text_Provided()
    {
        var description = new ScoreBlog.Domain.ValueObjects.Description(""); 
        Assert.False(description.IsValid); 
        Assert.Contains(description.Notifications, n => n.Message == "Description cannot be null or empty");
    }
}