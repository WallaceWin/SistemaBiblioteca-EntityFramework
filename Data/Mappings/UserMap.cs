using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    // public int Id { get; set; }
    // public string Name { get; set; } = string.Empty;
    // public string Email { get; set; } = string.Empty;
    // public string Password { get; set; } = string.Empty;
    // public List<Book>? Books { get; set; }
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x=>x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);
        
        builder.Property(x=>x.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");
    }
}