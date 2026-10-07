using System;
using System.Runtime.InteropServices;
using Habit_Logger_Me.Infra;
using Habit_Logger_Me.Models;

namespace Habit_Logger_Me.Repositories;

public class HabitRepository : IHabitRepository
{
    public bool ExistsId(int id)
    {
        using var command = DatabaseConnection.Open().CreateCommand();
        command.CommandText = @"SELECT 1 FROM Habits WHERE Id_Habit = $Id_Habit";
        command.Parameters.AddWithValue("$Id_Habit",id);
        return command.ExecuteScalar() is not null;
    }
    public void CreateHabits(Habit habit)
    {
        using var command = DatabaseConnection.Open().CreateCommand();
        command.Parameters.AddWithValue("$nameHabit", habit.NameHabit);
        command.Parameters.AddWithValue("$unit", habit.Unit);
        command.CommandText = @"INSERT INTO Habits (Habit, Unit) VALUES ($namehabit, $unit);";
        command.ExecuteNonQuery();
    }
    List<Habit> IHabitRepository.GetAllHabits()
    {
        List<Habit> HabitList = new List<Habit>();

        using var command = DatabaseConnection.Open().CreateCommand();
        command.CommandText = @"SELECT Id_Habit, Habit, Unit FROM Habits";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            HabitList.Add(new Habit
            (
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2)
            ));
        }

        return HabitList;
    }
    public void UpdateHabit(Habit habit)
    {
        using var connection = DatabaseConnection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE Habits SET Habit = $habit, Unit = $unit WHERE Id_Habit = $id";
        command.Parameters.AddWithValue("$habit", habit.NameHabit);
        command.Parameters.AddWithValue("$unit", habit.Unit);
        command.Parameters.AddWithValue("$id", habit.Id);
        command.ExecuteNonQuery();
    }
    public void DeleteHabit(int id)
    {
        using var command = DatabaseConnection.Open().CreateCommand();
        command.CommandText = @"DELETE FROM Habits WHERE Id_habit = $habitId";
        command.Parameters.AddWithValue("$habitId", id);
        command.ExecuteNonQuery();
    }   
}
