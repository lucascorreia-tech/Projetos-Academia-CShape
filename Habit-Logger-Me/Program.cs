namespace Habit_Logger_Me;

class Program
{
    public static void Main()
    {
        DatabaseConnection.Initialize();

        bool closeApp = false;
        while (closeApp == false)
        {
            Console.WriteLine("\n\nWelcome to Register your habits !!");
            Console.WriteLine("\nChoose a opetion:");
            Console.WriteLine("\nType 0 to close Application");
            Console.WriteLine("Type 1 to Create a Habit");
            Console.WriteLine("Type 2 to View All Habits");
            Console.WriteLine("Type 3 to Update a Habit");
            Console.WriteLine("Type 4 to Delete a Habit");
            Console.Write("Option: ");
            string? command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    HabitRepository.CreateHabits();
                    break;
                case "2":
                    HabitRepository.GetAllHabits();
                    break;
                case "3":
                    HabitRepository.UpdateHabit();
                    break;
                case "4":
                    HabitRepository.DeleteHabit();
                    break;
                default:
                    Console.WriteLine("This is not an acceptable option; please try again.");
                    break;
            }
        }
    }
}
