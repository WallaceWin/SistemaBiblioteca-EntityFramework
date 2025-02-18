using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers;

static public class LoanController
{
    static public void Loan()
    {
        while (true)
        {
            Console.WriteLine(@"O que deseja fazer? 
                [0] sair
                [1] Emprestar Livro
                [2] Devolver Livros
                [3] Conferir Emprestimos
            ");
            var option = Console.ReadLine();
            
            if (option == "0") break;

            switch (option)
            {
                case "1":
                    Console.Clear();
                    LoanBook();
                    break;
                case "2":
                    Console.Clear();
                    ReturnBook();
                    break;
                case "3":
                    Console.Clear();
                    ShowLoans();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

    private static void LoanBook()
    {
        Console.WriteLine("Emprestimo de livros");
        Console.WriteLine("Digite o id do livro a ser emprestado: ");
        var bookId = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o id do usuario que vai receber o livro: ");
        var userId = int.Parse(Console.ReadLine());

        try
        {
            Book book;
            User user;
            using (var context = new BooksDataContext())
            {
                book = context.Books.FirstOrDefault(x =>x.Id == bookId);
                user = context.Users.FirstOrDefault(x =>x.Id == userId);

                if (book.Borrowed)
                {
                    Console.WriteLine("Ja emprestado");
                    return;
                }

                var loan = new Loan
                {
                    Book = book,
                    User = user
                };
                context.Loans.Add(loan);
                book.Borrowed = true;
                context.SaveChanges();
            }
            
            Console.WriteLine("O livro foi emprestado com sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private static void ReturnBook()
    {
        Console.WriteLine("Devolução de livros");
        Console.WriteLine("Digite o id do livro a ser retornado: ");
        var bookId = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o id do usuario que vai Devolver: ");
        var userId = int.Parse(Console.ReadLine());

        try
        {
            Book book;
            User user;

            using (var context = new BooksDataContext())
            {
                book = context.Books.FirstOrDefault(x =>x.Id == bookId);
                user = context.Users.FirstOrDefault(x =>x.Id == userId);
                var loan = context.Loans.FirstOrDefault(x=>x.BookId == book.Id && x.UserId == user.Id);

                if (loan != null)
                {
                    context.Loans.Remove(loan);
                    book.Borrowed = false;
                    context.SaveChanges();
                    Console.WriteLine("O livro foi retornado com sucesso!");
                    return;
                }
                
                Console.WriteLine("Não existe esse emprestimo!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static void ShowLoans()
    {
        Console.WriteLine("Livros emprestados");
        
        try
        {   
            List<Book> books;
            List<User> users;
            List<Loan> loans;
            using (var context = new BooksDataContext())
            {
                loans = context.Loans.AsNoTracking().ToList();
                books = context.Books.AsNoTracking().ToList();
                users = context.Users.AsNoTracking().ToList();
            }

            foreach (var loan in loans)
            {
                Console.WriteLine($"Usuário que está com o livro: {users.FirstOrDefault(x => x.Id == loan.UserId).Name} - livro: {books.FirstOrDefault(x => x.Id == loan.BookId).Name}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}