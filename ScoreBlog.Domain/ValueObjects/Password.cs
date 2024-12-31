using System.Security.Cryptography;
using System.Text;
using Flunt.Br;

namespace ScoreBlog.Domain.ValueObjects;

internal sealed class Password : BaseValueObject
{
    public string Hash { get; private set; }
    public string Salt { get; private set; }
    
    public Password(string password)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNullOrEmpty(password, Key, "Password cannot be null or empty")
                .IsGreaterThan(password.Length, 6, Key, "Password must be at least 6 characters long")
        );

        if (!IsValid) return;
        Salt = GenerateSalt();
        Hash = GenerateHash(password, Salt);
    }
    
    public Password(string hash, string salt)
    {
        Hash = hash;
        Salt = salt;
    }

    private string GenerateSalt()
    {
        var saltBytes = new byte[16]; 
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);  
        }
        return Convert.ToBase64String(saltBytes); 
    }

    private string GenerateHash(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var combined = password + salt;
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined)); // Gerando o hash
            return Convert.ToBase64String(hashBytes); // Convertendo para string Base64
        }
    }

    public bool VerifyPassword(Password password)
    {
        return this.Hash.Equals(password.Hash);
    }
}
