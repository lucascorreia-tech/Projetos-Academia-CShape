using System;
using Habit_Logger_Me.Models;

namespace Habit_Logger_Me.Repositories;

public interface IHabitRepository
{
    bool ExistsId(int id);
    void InsertHabits(Habit habit);
    List<Habit> GetAllHabits();
    void UpdateHabit(Habit habit);
    void DeleteHabit(int id);
}
