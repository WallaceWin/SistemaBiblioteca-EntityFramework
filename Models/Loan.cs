﻿namespace Biblioteca.Models;

public class Loan
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public DateTime LoanDate { get; set; }
}