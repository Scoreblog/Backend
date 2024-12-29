namespace ScoreBlog.Tests.Red.Domain.VO.BirthDate;

public class BirthDateTests
{
    [Fact]
    public void BirthDate_Should_Be_Invalid_When_Invalid_Date_Provided()
    {
        var birthDate = new ScoreBlog.Domain.ValueObjects.BirthDate(DateTime.Today.AddDays(1)); 
        Assert.False(birthDate.IsValid); 
        Assert.Contains(birthDate.Notifications, n => n.Message == "Date of Birth cannot be greater than today");
    }
}