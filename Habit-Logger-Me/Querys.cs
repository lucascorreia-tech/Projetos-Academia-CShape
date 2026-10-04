using System.Runtime.InteropServices;

namespace Habit_Logger_Me;
public static class Querys
{
    public static void CreateHabits(string nameHabit, string unit)
    {
        var command = DatabaseConnection.Open().CreateCommand();
        command.Parameters.AddWithValue("$namehabit", nameHabit);
        command.Parameters.AddWithValue("$unit", unit);
        command.CommandText = @"
            INSERT INTO Habits (Habit, Unit) VALUES ($namehabit, $unit);
        ";
        command.ExecuteNonQuery();
    }
    public static void AllHabits() {}
    public static void Insert() {}
    public static void Update() {}
    public static void Delete() {}
}