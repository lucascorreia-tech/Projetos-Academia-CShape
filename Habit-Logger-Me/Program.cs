using Habit_Logger_Me.Infra;
using Habit_Logger_Me.UI;

namespace Habit_Logger_Me;

class Program
{
    public static void Main()
    {
        DatabaseInitializer.Initialize();

        bool AppClose = false;

        while (!AppClose)
        {
            var option = Menu.GetInputUser();

            switch (option)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    ConsoleHabit.CreateHabit();
                    break;
                case "2":
                    ConsoleHabit.AllHabits();
                    break;
                case "3":
                    ConsoleHabit.UpdateHabit();
                    break;
                case "4":
                    ConsoleHabit.DeleteHabit();
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case null:
                    Console.WriteLine("This is not a option");
                    break;
            }
        }
    }
}
