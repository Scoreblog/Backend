namespace ScoreBlog.Tests.Green.Domain.VO.Description;

public class DescriptionTests
{
    [Fact]
    public void Description_Should_Be_Valid_When_Valid_Text_Provided()
    {
        var description = new ScoreBlog.Domain.ValueObjects.Description("This is a valid description");
        Assert.True(description.IsValid); 
    }
}