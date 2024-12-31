using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Tests.Green.Domain.Entities;

public class PictureTests
{
    [Fact]
    public void Picture_Should_Be_Valid_When_Valid_Properties_Are_Provided()
    {
        // Arrange
        var fileContent = new byte[5000];  // Exemplo de conteúdo de arquivo válido (5KB)
        var fileStream = new System.IO.MemoryStream(fileContent);
        var appFile = new AppFile(fileStream, "image.jpg");
        var name = new UniqueName("Picture1");
        var awsKey = "valid-aws-key";
        var urlExpired = DateTime.Now.AddDays(1); // Data de expiração no futuro
        var urlTemp = "https://example.com/temp-image-url";
        var ativo = true;

        var picture = new Picture(appFile, name, awsKey, urlExpired, urlTemp, ativo);

        Assert.True(picture.IsValid);  
        Assert.Equal(awsKey, picture.AwsKey);  // A chave AWS deve ser válida
        Assert.Equal(urlTemp, picture.UrlTemp);  // A URL temporária deve ser válida
        Assert.True(picture.Ativo);  // O status 'Ativo' deve ser verdadeiro
    }
}