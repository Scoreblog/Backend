using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Tests.Red.Domain.Entities;

public class PropertyTests
{
    [Fact]
    public void Property_Should_Be_Invalid_When_Properties_Are_Invalid()
    {
        // Arrange
        var name = new UniqueName(""); // Nome inválido
        var property = new Property(name, "https://example.com/icon.png");

        // Act & Assert
        Assert.False(property.IsValid); // O objeto deve ser inválido
        Assert.Contains(property.Notifications, n => n.Message == "Name cannot be null or empty");
    }
}