using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Mappings;

public class BookMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        
        builder.ToTable("Book");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x=>x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Author)
            .IsRequired()
            .HasColumnName("Author")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x=>x.Borrowed)
            .IsRequired()
            .HasColumnName("Borrowed")
            .HasColumnType("BIT")
            .HasDefaultValue(0);
        
        builder.Property(x=>x.Genre)
            .IsRequired()
            .HasColumnName("Genre")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x=>x.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");
    }
}