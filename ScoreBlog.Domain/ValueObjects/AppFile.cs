using Flunt.Br;

namespace ScoreBlog.Domain.ValueObjects;

internal class AppFile : BaseValueObject 
{
    public Stream File { get; private set; }
    public string FileName { get; private set; }
    public long FileSize { get; private set; }

    public AppFile(Stream file, string fileName)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNull(file, "AppFile.File", "File cannot be null")
                .IsLowerThan(file.Length, 10_000_000, "AppFile.File", "File size must be less than 10MB")  // Example size validation
                .IsNotNullOrEmpty(fileName, "AppFile.FileName", "File name cannot be null or empty")
        );

        if (!IsValid) return;
        File = file;
        FileName = fileName;
        FileSize = file.Length;
    }
}
