using Flunt.Br;

namespace ScoreBlog.Domain.ValueObjects;

internal class Email : BaseValueObject
{
    public string? Address { get; private set; }
    
    public Email(string? address)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsEmail(address, Key, "Email invalid")
            );
        Address = address;
    }
}