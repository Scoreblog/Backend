using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Tests.Green.Domain.Entities;

public class PropertyTests
{
    [Fact]
    public void Property_Should_Be_Valid_When_Valid_Properties_Are_Provided()
    {
        var name = new UniqueName("Property1");
        var property = new Property(name, "https://example.com/icon.png");
        Assert.True(property.IsValid); 
    }
}