namespace Biblioteca.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Loan> Loans { get; set; } =  new List<Loan>();
    
    public DateTime CreatedAt { get; set; }
}