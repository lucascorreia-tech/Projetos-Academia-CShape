using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Habit_Logger_Me;
public static class HabitRepository
{
    public static void CreateHabits()
    {
        string nameHabit = AuxiliaryMethods.GetInputStr("\nWrite your habit: ");
        string unit = AuxiliaryMethods.GetInputStr("\nWrite the unit of measure");

        using var command = DatabaseConnection.Open().CreateCommand();
        command.Parameters.AddWithValue("$namehabit", nameHabit);
        command.Parameters.AddWithValue("$unit", unit);
        command.CommandText = @"
            INSERT INTO Habits (Habit, Unit) VALUES ($namehabit, $unit);
        ";
        command.ExecuteNonQuery();
    }
    public static void GetAllHabits()
    {
        var habitsList = new List<Habits>();

        using var command = DatabaseConnection.Open().CreateCommand();
        command.CommandText = @"SELECT Id_Habit, Habit, Unit FROM Habits";
        var reader = command.ExecuteReader();

       while (reader.Read())
        {
            habitsList.Add(new Habits
            {
                Id_habit = reader.GetInt32(0),
                Habit = reader.GetString(1),
                Unit = reader.GetString(2)
            });
        }

        Console.WriteLine("--------------------------------------------\n");
        foreach (var ht in habitsList)
        {
            Console.WriteLine($"{ht.Id_habit} - {ht.Habit} - {ht.Unit}");
        }
        Console.WriteLine("--------------------------------------------\n");
    }
    public static void UpdateHabit()
    {
        Console.Clear();
        GetAllHabits();

        var habitId = AuxiliaryMethods.GetNumberInput("\n\nPlease type Id of the Habit would like to Update\n \n");

        using var connection = DatabaseConnection.Open();

        using var checkCmd = connection.CreateCommand();
        checkCmd.CommandText = @"SELECT 1 FROM Habits WHERE Id_Habit = $Id_Habit";
        checkCmd.Parameters.AddWithValue("$Id_Habit",habitId);
        int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());

        if (checkQuery == 0)
        {
            Console.WriteLine($"\n\nHabit with Id {habitId} doesn't exist.\n\n");
            UpdateHabit();
            return;
        }

        string? habit = AuxiliaryMethods.GetInputStr("Write a name change: ");
        string? unit = AuxiliaryMethods.GetInputStr("write a unit change: ");

        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText = @"UPDATE Habits SET habit= $habit, unit= $unit WHERE Id_Habit= $id";
        tableCmd.Parameters.AddWithValue("$habit", habit);
        tableCmd.Parameters.AddWithValue("$unit", unit);
        tableCmd.Parameters.AddWithValue("$id",habitId);

        tableCmd.ExecuteNonQuery();
    }
    public static void DeleteHabit()
    {
        Console.Clear();
        GetAllHabits();

        var habitId = AuxiliaryMethods.GetNumberInput("\n\nPlease type Id of the Habit would like to Delete\n \n");

        using var connection = DatabaseConnection.Open();

        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText = @"DELETE FROM Habits WHERE Id_Habit = $habitId";
        tableCmd.Parameters.AddWithValue("$habitId", habitId);

        int rowCount = tableCmd.ExecuteNonQuery();

        if (rowCount == 0)
        {
            Console.WriteLine($"\n\nHabit with Id {habitId} doens't exist. \n\n");
            DeleteHabit();
            return;
        }

        Console.WriteLine($"\n\nHabit with Id {habitId} was delete. \n\n");
    }
}