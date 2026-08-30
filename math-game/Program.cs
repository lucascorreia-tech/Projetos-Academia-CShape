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
            Console.WriteLine("===============================\nBem vindo ao Jogo Matématico.\n===============================");
            Console.WriteLine("\nEscolha uma opção abaixo:");
            Console.WriteLine("1- Jogo fácil\n2- Jogo intermédiario\n3- Jogo Difícil\n4- Listar Pontuações\n0- Sair do jogo");
            op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    pontos = lb.Easy();
                    rodadas.Add(pontos);
                    break;
                case 2:
                    pontos = lb.Inter();
                    rodadas.Add(pontos);
                    break;
                case 3:
                    pontos = lb.Dificult();
                    rodadas.Add(pontos);
                    break; 
                case 4:
                    Console.WriteLine("=====================\n=PONTUAÇÃO DOS JOGOS=\n=====================");
                    for (int i = 0; i < rodadas.Count; i++)
                    {
                        Console.WriteLine($"Rodada {i + 1}° -> {rodadas[i]} pontos");
                    }
                    Console.WriteLine();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }while(op != 0);
        
    }

}