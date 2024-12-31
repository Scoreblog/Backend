using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Tests.Green.Domain.Entities;

public class UserTests
{
    [Fact]
    public void User_Should_Be_Valid_When_Valid_Properties_Are_Provided()
    {
        // Arrange
        var fullName = new FullName("John", "Doe");
        var email = new Email("john.doe@example.com");
        var address = new Address(123, "Downtown", "Main St", "Apt 101");
        var birthDate = new BirthDate(new DateTime(1990, 1, 1));
        var user = new User(fullName, email, address, birthDate, true);
        Assert.True(user.IsValid); 
    }
}