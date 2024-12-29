namespace ScoreBlog.Tests.Red.Domain.VO.UniqueName;

public class UniqueNameTests
{
    [Fact]
    public void UniqueName_Should_Be_Invalid_When_Invalid_Name_Provided()
    {
        var uniqueName = new ScoreBlog.Domain.ValueObjects.UniqueName(""); 
        Assert.False(uniqueName.IsValid); 
        Assert.Contains(uniqueName.Notifications, n => n.Message == "Name cannot be null or empty");
    }
}