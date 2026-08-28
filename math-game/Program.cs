using System;

public class Program
{
    public static void Main()
    {
        int op = 0;
        do
        {
            Console.WriteLine("Bem vindo ao Jogo de Matématico.");
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1- Jogo fácil\n0- Sair do jogo");
            switch (op)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }while(op != 0);
        
    }

}

