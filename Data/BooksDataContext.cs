using Biblioteca.Data.Mappings;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data;

public class BooksDataContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=Library;User ID=sa;Password=Banano2@;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new LoanMap());
    }
}