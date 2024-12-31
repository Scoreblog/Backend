namespace ScoreBlog.Tests.Green.Domain.VO.AppFile;

public class AppFileTests
{
    [Fact]
    public void AppFile_Should_Be_Valid_When_Valid_Properties_Are_Provided()
    {
        // Arrange
        var fileContent = new byte[5000];  // 5KB (válido)
        var fileStream = new MemoryStream(fileContent);
        var fileName = "valid-file.pdf";

        // Criando o AppFile
        var appFile = new ScoreBlog.Domain.ValueObjects.AppFile(fileStream, fileName);

        // Act & Assert
        Assert.True(appFile.IsValid); 
        Assert.Equal(fileName, appFile.FileName); 
        Assert.Equal(fileContent.Length, appFile.FileSize); // O tamanho do arquivo deve ser 5KB
    }
}
