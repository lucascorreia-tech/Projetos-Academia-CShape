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
            Console.Write("Option: ");
            string? command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    string habit = AuxiliaryMethods.GetInputStr("\nWrite your habit: ");
                    string unit = AuxiliaryMethods.GetInputStr("\nWrite the unit of measure");
                    Querys.CreateHabits(habit,unit);
                    break;
                default:
                    Console.WriteLine("This is not an acceptable option; please try again.");
                    break;
            }
        }
    }
}
