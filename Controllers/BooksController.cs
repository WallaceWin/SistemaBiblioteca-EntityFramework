using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers;

static public class BooksController
{
    static public void Book()
    {
        while (true)
        {
            Console.WriteLine(@"O que deseja fazer? 
                [0] sair
                [1] Cadastrar Livro
                [2] Listar Livros
                [3] Atualizar Livro
                [4] Deletar Livro
            ");
            var option = Console.ReadLine();
            
            if (option == "0") break;

            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreateBook();
                    break;
                case "2":
                    Console.Clear();
                    ShowBooks();
                    break;
                case "3":
                    Console.Clear();
                    UpdateBooks();
                    break;
                case "4":
                    Console.Clear();
                    DeleteBooks();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

    static private void CreateBook()
    {
        Console.WriteLine("Cadastro de Livros");
        Console.Write("Digite o nome do livro: ");
        var name = Console.ReadLine();
        Console.Write("Digite o Autor do livro: ");
        var author = Console.ReadLine();
        Console.Write("Digite o Genero do livro: ");
        var genre = Console.ReadLine();

        var book = new Book
        {
            Name = name,
            Author = author,
            Genre = genre
        };

        try
        {
            using (var context = new BooksDataContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            
            Console.WriteLine("Livro cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    static private void ShowBooks()
    {
        List<Book> books;

        using (var context = new BooksDataContext())
        {
            books = context.Books.AsNoTracking().ToList();
        }

        foreach (var book in books)
        {
            Console.WriteLine($"Nome do livro: {book.Name} - Autor: {book.Author} - Genero: {book.Genre} - Emprestado: {book.Borrowed}");
        }
    }

    static private void UpdateBooks()
    {
        Console.WriteLine("Digite o Id do livro a ser atualizado: ");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o nome do livro a ser atualizado: ");
        var name = Console.ReadLine();
        Console.WriteLine("Digite o Autor do livro a ser atualizado: ");
        var author = Console.ReadLine();
        Console.WriteLine("Digite o Genero do livro a ser atualizado: ");
        var genre = Console.ReadLine();

        try
        {
            using (var context = new BooksDataContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id == id);
                book.Name = name;
                book.Author = author;
                book.Genre = genre;
                context.SaveChanges();
            }
            
            Console.WriteLine("Atualizado com sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    async static private void DeleteBooks()
    {
        Console.WriteLine("Digite o Id do livro a ser Deletado: ");
        var id = int.Parse(Console.ReadLine());

        try
        {
            using (var context = new BooksDataContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id == id);
                context.Books.Remove(book);
                context.SaveChanges();
            }
            
            Console.WriteLine("Deletado com sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}