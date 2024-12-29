namespace ScoreBlog.Tests.Green.Domain.VO.UniqueName;

public class UniqueNameTests
{
    [Fact]
    public void UniqueName_Should_Be_Valid_When_Valid_Name_Provided()
    {
        var uniqueName = new ScoreBlog.Domain.ValueObjects.UniqueName("UniqueName123");
        Assert.True(uniqueName.IsValid); 
    }
}