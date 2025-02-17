
using Biblioteca.Controllers;
using Biblioteca.Data;
using Biblioteca.Models;

main();

static void main()
{
    while (true)
    {
        Console.WriteLine(
            @"Escolha uma opção
            [0] Sair
            [1] Livros
            [2] Usuarios
            [3] Emprestimos
            ");
        var opcao = Console.ReadLine();

        if (opcao == "0") break;

        switch (opcao)
        {
            case "1":
                Console.Clear();
                BooksController.Book();
                break;
            case "2":
                Console.Clear();
                UsersController.User();
                break;
            case "3":
                Console.Clear();
                LoanController.Loan();
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

}