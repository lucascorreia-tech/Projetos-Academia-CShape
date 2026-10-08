namespace Habit_Logger_Me.UI;

public static class Menu
{
    public static string GetInputUser()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------\n-------------Welcome to Habit Logger------\n----------------------------------------\n\n");

        Console.WriteLine("Choose your opetion:");
        Console.WriteLine("0 - Close Program");
        Console.WriteLine("1 - Create a Habit");
        Console.WriteLine("2 - Show all Habit");
        Console.WriteLine("3 - Update a Habit");
        Console.WriteLine("4 - Delete a Habit");
        Console.WriteLine("5 - Create a Record");
        Console.WriteLine("6 - Show all Record from a Habit");
        Console.WriteLine("7 - Update a Record");
        Console.WriteLine("8 - Delete a Record\n");

        Console.Write("Your Opetion: ");
        string command = ConsoleInput.GetInputStr();
        return command;
    }
}