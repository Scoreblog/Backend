namespace ScoreBlog.Tests.Green.Domain.VO.FullName;

public class FullNameTests
{
    [Fact]
    public void FullName_Should_Be_Valid_When_Valid_Properties_Provided()
    {
        var fullName = new ScoreBlog.Domain.ValueObjects.FullName("John", "Doe");
        Assert.True(fullName.IsValid); 
    }
}