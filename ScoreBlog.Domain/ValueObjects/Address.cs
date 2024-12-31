using Flunt.Br;
using Flunt.Notifications;

namespace ScoreBlog.Domain.ValueObjects;

internal class Address : BaseValueObject
{
    public string? Road { get; private set; }
    public string? NeighBordHood { get; private set; }
    public long? Number { get; private set; }
    public string? Complement  { get; private set; }

    public Address(long? number, string? neighBordHood, string? road, string? complement)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsGreaterThan((double)number!, 0.0, Key, "Number must be greater than 0")
                .IsNotNullOrEmpty(road, Key, "Road is required")
                .IsNotNullOrEmpty(neighBordHood, Key, "Neighborhood is required")
                .IsLowerThan(complement!.Length, 100, Key, "Complement must not exceed 100 characters")
        );

        Number = number;
        NeighBordHood = neighBordHood;
        Road = road;
        Complement = complement;
    }
}