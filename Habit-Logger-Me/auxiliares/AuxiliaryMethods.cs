using System;

namespace Habit_Logger_Me;

public static class AuxiliaryMethods
{
    public static string GetInputStr(string text)
    {
        Console.WriteLine(text);
        string? inputStr = Console.ReadLine();
        return inputStr!;
    }

    public static int GetNumberInput(string text)
    {
        Console.WriteLine(text);
        string? numberInput = Console.ReadLine();

        while (!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
        {
            Console.WriteLine("\n\nInvalid number. Try again.\n\n");
            numberInput = Console.ReadLine();
        }

        int finalInput = Convert.ToInt32(numberInput);

        return finalInput;
    }
}
