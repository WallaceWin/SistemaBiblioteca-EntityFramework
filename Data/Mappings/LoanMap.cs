using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Mappings;

public class LoanMap : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loan");

        builder.HasKey(x => new { x.UserId, x.BookId });

        builder.HasOne(x => x.User)
            .WithMany(x => x.Loans)
            .HasForeignKey(x => x.UserId);
        
        builder.HasOne(x => x.Book)
            .WithMany(x => x.Loans)
            .HasForeignKey(x => x.BookId);
        
        builder.Property(x=>x.LoanDate)
            .HasColumnName("LoanDate")
            .IsRequired()
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");
    }
}