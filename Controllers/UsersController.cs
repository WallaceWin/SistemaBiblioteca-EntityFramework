using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers;

static public class UsersController
{
    static public void User()
    {
        while (true)
        {
            Console.WriteLine(@"O que deseja fazer? 
                [0] sair
                [1] Cadastrar user
                [2] Listar users
                [3] Atualizar user
                [4] Deletar user
            ");
            var option = Console.ReadLine();
            
            if (option == "0") break;

            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreateUser();
                    break;
                case "2":
                    Console.Clear();
                    ShowUsers();
                    break;
                case "3":
                    Console.Clear();
                    UpdateUser();
                    break;
                case "4":
                    Console.Clear();
                    DeleteUser();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

    private static void CreateUser()
    {
        Console.WriteLine("Criar novo usario");
        Console.WriteLine("Digite o nome: ");
        var name = Console.ReadLine();
        Console.WriteLine("Digite o Email: ");
        var email = Console.ReadLine();
        Console.WriteLine("Digite a Senha: ");
        var password = Console.ReadLine();

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password
        };

        try
        {
            using (var context = new BooksDataContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static void ShowUsers()
    {
        Console.WriteLine("Listar Usuarios");
        List<User> users;

        try
        {
            using (var context = new BooksDataContext())
            {
                users = context.Users.AsNoTracking().ToList();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id} - Nome: {user.Name} - Email: {user.Email}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static void UpdateUser()
    {
        Console.WriteLine("Atualizar Usuario");
        Console.WriteLine("Digite o Id do usuario a ser atualizado: ");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o nome a ser atualizado: ");
        var name = Console.ReadLine();
        Console.WriteLine("Digite o Email a ser atualizado: ");
        var email = Console.ReadLine();
        Console.WriteLine("Digite a Senha a ser atualizado: ");
        var password = Console.ReadLine();

        try
        {
            User user;
            using (var context = new BooksDataContext())
            {
                user = context.Users.FirstOrDefault(x=>x.Id == id);
                user.Name = name;
                user.Email = email;
                user.Password = password;
                context.SaveChanges();
            }
            
            Console.WriteLine("Atualizado com sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static void DeleteUser()
    {
        Console.WriteLine("Deletar Usuario");
        Console.WriteLine("Digite o Id do usuario a ser deletado: ");
        var id = int.Parse(Console.ReadLine());

        try
        {
            User user;
            using (var context = new BooksDataContext())
            {
                user = context.Users.FirstOrDefault(x=>x.Id == id);
                context.Users.Remove(user);
                context.SaveChanges();
            }
            
            Console.WriteLine("Usuario deletado com sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}