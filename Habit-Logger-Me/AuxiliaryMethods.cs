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
}
