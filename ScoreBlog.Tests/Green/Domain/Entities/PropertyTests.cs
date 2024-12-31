using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Tests.Green.Domain.Entities;

public class PropertyTests
{
    [Fact]
    public void Property_Should_Be_Valid_When_Valid_Properties_Are_Provided()
    {
        // Arrange
        var name = new UniqueName("Property1");
        var property = new Property(name, "https://example.com/icon.png");
        // Act & Assert
        Assert.True(property.IsValid); // O objeto deve ser válido
    }
}