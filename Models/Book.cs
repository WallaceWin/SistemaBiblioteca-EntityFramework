namespace Biblioteca.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool Borrowed { get; set; }
    public string Genre { get; set; } = string.Empty;
    public List<Loan> Loans { get; set; } =  new List<Loan>();
    public DateTime CreatedAt { get; set; }
}