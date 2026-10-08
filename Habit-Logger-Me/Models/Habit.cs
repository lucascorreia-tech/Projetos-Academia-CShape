using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Habit_Logger_Me.Models;

public class Habit
{
    public int Id {get; }
    public string NameHabit {get; }
    public string Unit {get; }

    public Habit(int id, string nameHabit, string unit)
    {
        Id = id;
        NameHabit = nameHabit;
        Unit = unit;
    }

    public Habit(string nameHabit, string unit)
    {
        NameHabit = nameHabit;
        Unit = unit;
    }
}