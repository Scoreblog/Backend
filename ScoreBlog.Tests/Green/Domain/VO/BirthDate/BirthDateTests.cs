namespace ScoreBlog.Tests.Green.Domain.VO.BirthDate;

public class BirthDateTests
{
    [Fact]
    public void BirthDate_Should_Be_Valid_When_Valid_Date_Provided()
    {
        var birthDate = new ScoreBlog.Domain.ValueObjects.BirthDate(new DateTime(2000, 5, 10));
        Assert.True(birthDate.IsValid); 
    }
}