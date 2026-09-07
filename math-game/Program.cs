using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        int op = 0;
        int pontos = 0;
<<<<<<< HEAD
        Libary lb = new();
        double tempo_jogo = 0;
        List<int> rodadas = [];
        List<double> tempo_rodadas = [];
=======
        Library lb = new();
        double tempo_jogo = 0;
        List<int> rodadas = [];
        List<double> tempo_rodadas = [];
        string operador = "";

>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
        do
        {
            Console.WriteLine("===============================\nBem vindo ao Jogo Matématico.\n===============================");
            Console.WriteLine("\nEscolha uma opção abaixo:");
<<<<<<< HEAD
            Console.WriteLine("1- Jogo fácil\n2- Jogo intermédiario\n3- Jogo Difícil\n4- Listar Pontuações\n0- Sair do jogo");
            op = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (op)
            {
                case 1:
                    tempo_jogo = Time.MedirTempo(() => pontos = lb.Easy());
                    rodadas.Add(pontos);
                    tempo_rodadas.Add(tempo_jogo);
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
                        Console.WriteLine($"Rodada {i + 1}° -> {rodadas[i]} pontos | Tempo -> {(int)tempo_rodadas[i]} segundos");
                    }
                    Console.ReadLine();
                    Console.WriteLine();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
=======
            Console.WriteLine("1- Jogo fácil\n2- Jogo intermédiario\n3- Jogo Difícil\n4- Jogo Aleátorio\n5- Listar Pontuações\n0- Sair do jogo");
    
            if (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite apenas números!\n");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                // PARA O C# PARA DE CONVERTE PARA 0
                op = -1;
                Console.Clear();
                continue;
            }

            Console.Clear();

            try
            {
                switch (op)
                {
                    case 1:
                        operador = lb.EscolhaOperador();
                        tempo_jogo = Time.MedirTempo(() => pontos = lb.Jogar(operador, 10, 10));
                        rodadas.Add(pontos);
                        tempo_rodadas.Add(tempo_jogo);
                        break;
                    case 2:
                        operador = lb.EscolhaOperador();
                        tempo_jogo = Time.MedirTempo(() => pontos = lb.Jogar(operador, 10, 50));
                        rodadas.Add(pontos);
                        tempo_rodadas.Add(tempo_jogo);
                        break;
                    case 3:
                        operador = lb.EscolhaOperador();
                        tempo_jogo = Time.MedirTempo(() => pontos = lb.Jogar(operador, 50, 100));
                        rodadas.Add(pontos);
                        tempo_rodadas.Add(tempo_jogo);
                        break;
                    case 4:
                        tempo_jogo = Time.MedirTempo(() => pontos = lb.Jogar("aleatorio", 100, 100));
                        rodadas.Add(pontos);
                        tempo_rodadas.Add(tempo_jogo);
                        break; 
                    case 5:
                        Console.WriteLine("=====================\n=PONTUAÇÃO DOS JOGOS=\n=====================");
                        if (rodadas.Count==0)
                        {
                            Console.WriteLine("Nenhuma partida Jogada");
                        }
                        else
                        {
                            for (int i = 0; i < rodadas.Count; i++)
                            {
                                Console.WriteLine($"Rodada {i + 1}° -> {rodadas[i]} pontos | Tempo -> {(int)tempo_rodadas[i]} segundos");
                            }
                        }
                        Console.WriteLine("\nPressione ENTER para voltar ao menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } catch (ArgumentException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERRO]: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }
            
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
        }while(op != 0);
        
    }
}