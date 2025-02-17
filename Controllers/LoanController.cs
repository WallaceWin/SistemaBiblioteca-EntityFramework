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
                [3] Conferir Livro
            ");
            var option = Console.ReadLine();
            
            if (option == "0") break;

            switch (option)
            {
                case "1":
                    Console.WriteLine("Emprestar Livro");
                    break;
                case "2":
                    Console.WriteLine("Devolver Livros");
                    break;
                case "3":
                    Console.WriteLine("Conferir Livro");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}