using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities;

internal class Picture : Entity
{
    public Stream File { get; private set; }
    public UniqueName Name { get; private set; }
    public string AwsKey { get;  private set; }
    public DateTime UrlExpired { get; private set; }
    public string UrlTemp { get; private set; }
    public bool Ativo { get; private set; }
}