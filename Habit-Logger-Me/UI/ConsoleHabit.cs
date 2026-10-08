using System;
using Habit_Logger_Me.Models;
using Habit_Logger_Me.Repositories;
using Habit_Logger_Me.Services;

namespace Habit_Logger_Me.UI;

public static class ConsoleHabit
{
    static readonly HabitService service = new HabitService(new HabitRepository());
    public static void CreateHabit()
    {
        Console.Clear();
        Console.WriteLine("|----------------|");
        Console.WriteLine("|Creating a Habit|");
        Console.WriteLine("|----------------|\n");

        Console.Write("Write the Name of Habit");
        string nameHabit = ConsoleInput.GetInputStr();
        Console.Write("\nWrite the Unit of Habit");
        string unit = ConsoleInput.GetInputStr();

        var habit = new Habit(nameHabit, unit);

        service.CreateHabit(habit);

        Console.WriteLine("\nHabit created sucessfully!");
    }

    public static void AllHabits()
    {
        Console.Clear();
        Console.WriteLine("|--------------------------------------------------|");
        Console.WriteLine("|----------------------All Habits------------------|");
        Console.WriteLine("|--------------------------------------------------|\n");

        var habitList = service.GetAllHabits();

        foreach (var habit in habitList)
        {
            Console.WriteLine($"{habit.Id} - {habit.NameHabit} - {habit.Unit}");
        }
    }

    public static void UpdateHabit()
    {
        Console.Clear();
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine("|----------------------Update Habit------------------|");
        Console.WriteLine("|----------------------------------------------------|\n");

        var habitList = service.GetAllHabits();

        foreach (var habit in habitList)
        {
            Console.WriteLine($"{habit.Id} - {habit.NameHabit} - {habit.Unit}");
        }

        Console.Write("\nWrite Id habit do you update: ");
        int id = ConsoleInput.GetNumberInput();

        Console.Write("\nWrite a new name for Habit: ");
        string habitName = ConsoleInput.GetInputStr();

        Console.Write("\nWrite a new unit for Habit: ");
        string unit = ConsoleInput.GetInputStr();

        var newHabit = new Habit(id,habitName, unit);

        try
        {
            service.UpdateHabit(newHabit);
            Console.WriteLine($"Habit with Id:{newHabit.Id} was Updated");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void DeleteHabit()
    {
        Console.Clear();
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine("|----------------------Delete Habit------------------|");
        Console.WriteLine("|----------------------------------------------------|\n");

        var habitList = service.GetAllHabits();

        foreach (var habit in habitList)
        {
            Console.WriteLine($"{habit.Id} - {habit.NameHabit} - {habit.Unit}");
        }

        Console.Write("\nWrite Id habit do you delete: ");
        int id = ConsoleInput.GetNumberInput();

        try
        {
            service.DeleteHabit(id);
            Console.WriteLine($"Habit with Id:{id} was Deleted");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
