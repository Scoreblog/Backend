using Flunt.Br;
using Flunt.Notifications;

namespace ScoreBlog.Domain.ValueObjects;

internal class BirthDate : BaseValueObject
{
    public DateTime Date { get; private set; }
    public BirthDate(DateTime date)
    {
        AddNotifications(
            new Contract().Requires().IsNotNull(date, Key, "Date of Birth cannot be null")
                .IsLowerThan(date, DateTime.Today, Key, "Date of Birth cannot be greater than today")
            );
    }
}