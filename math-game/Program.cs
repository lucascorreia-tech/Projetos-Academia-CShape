using System.Runtime.CompilerServices;

public class Program
{
    public static void Main()
    {
        int op = 0;
        int pontos = 0;
        Libary lb = new();
        List<int> rodadas = [];
        do
        {
            Console.WriteLine("Bem vindo ao Jogo de Matématico.");
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1- Jogo fácil\n5- Listar Pontuações\n0- Sair do jogo");
            op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    pontos = lb.Easy();
                    rodadas.Add(pontos);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Console.WriteLine("=====================\n=PONTUAÇÃO DOS JOGOS=\n=====================");
                    for (int i = 0; i < rodadas.Count; i++)
                    {
                        Console.WriteLine($"Rodada {i}° -> {rodadas[i]} pontos");
                    }
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }while(op != 0);
        
    }

}