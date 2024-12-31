using ScoreBlog.Domain.ValueObjects;

namespace ScoreBlog.Domain.Entities;

internal class User : Entity
{
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public BirthDate BirthDate { get;  private set; }
    public Password Password { get; private set; } 
    public bool Active { get; private set; }
    
    public User(FullName fullName, Email email, Address address, BirthDate birthDate, bool active, Password password)
    {
        AddNotificationsFromValueObjects(fullName, email, address, birthDate, password);
        FullName = fullName;
        Email = email;
        Address = address;
        BirthDate = birthDate;
        Active = active;
        Password = password;
    }
    
    //Construtor para validar utilizar no método de Autenticação
    public User(Email email,Password password)
    {
        AddNotificationsFromValueObjects(email, password);
        Password = password;
        Email = email;
    }
}