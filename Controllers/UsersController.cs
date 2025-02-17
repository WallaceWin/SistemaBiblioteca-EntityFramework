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
                    Console.WriteLine("Cadastrar User");
                    break;
                case "2":
                    Console.WriteLine("Listar Users");
                    break;
                case "3":
                    Console.WriteLine("Atualizar User");
                    break;
                case "4":
                    Console.WriteLine("Deletar User");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}