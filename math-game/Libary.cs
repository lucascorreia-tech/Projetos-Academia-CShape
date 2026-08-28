using System;

public class Libary
{
    private Random randNum = new();

    private string[] operadores = {"+", "-", "/", "x"};
    public static void Easy()
    {
        return;
    }

    public void NovasPerguntas(int x, int y)
    {
        string operador = operadores[randNum.Next(operadores.Length)];
        Console.WriteLine("Qual é resultado da conta abaixo ?");
        Console.WriteLine($"{x} {operador} {y}");
    }
}