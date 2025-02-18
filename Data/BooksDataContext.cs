using Biblioteca.Data.Mappings;
using Biblioteca.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data;

public class BooksDataContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        Env.Load();
        var server = Env.GetString("SERVER");
        var port = Env.GetInt("PORT");
        var db = Env.GetString("DATABASE");
        var user = Env.GetString("USER");
        var password = Env.GetString("PASSWORD");
        
        options.UseSqlServer($"Server={server},{port};Database={db};User ID={user};Password={password};TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new LoanMap());
    }
}