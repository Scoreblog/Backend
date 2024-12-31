using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using  ScoreBlog.Domain.Entities;
    
namespace ScoreBlog.Infrastructure.Data.FluentMapping;

internal class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users"); 
        builder.HasKey(u => u.Id).HasName("PK_Users");

        //Properties
        builder.Property(c => c.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .IsRequired().ValueGeneratedOnAdd();

        builder.Property(c => c.CreatedDate)
            .HasColumnName("CreatedDate")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(c => c.UpdatedDate)
            .HasColumnName("UpdatedDate")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(c => c.DeletedDate)
            .HasColumnName("DeletedDate")
            .HasColumnType("timestamp").IsRequired(false);
        
        builder.HasIndex(u => u.Email.Address).IsUnique();
        
        builder.Property(u => u.FullName.FirstName).HasMaxLength(100);
        builder.Property(u => u.FullName.LastName).HasMaxLength(100);
        builder.Property(u => u.Email.Address).HasColumnName("Email").HasMaxLength(50);

        builder.Property(u => u.Address.Road).HasColumnName("AddressRoad").HasMaxLength(100);
        builder.Property(u => u.Address.Number).HasColumnName("AddressNumber").HasColumnType("BIGINT");
        builder.Property(u => u.Address.NeighBordHood).HasColumnName("AddressNeighborHood").HasColumnType("varchar");
        
        builder.Property(u => u.Address.Complement).HasColumnName("AddressComplement").HasColumnType("varchar").HasMaxLength(100);
        builder.Property(u => u.BirthDate.Date).HasColumnName("BirthDate");
        builder.Property(u => u.Active).HasColumnName("Active");

        builder.Property(u => u.Password.Hash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.Password.Salt).HasColumnName("PasswordSalt").IsRequired();
        
    }
}