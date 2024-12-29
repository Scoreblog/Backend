using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities;

internal class User : Entity
{
    public FullName FullName { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
    public BirthDate BirthDate { get; set; }
    public bool Active { get; set; }
}