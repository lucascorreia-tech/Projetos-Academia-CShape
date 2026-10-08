using System;
using Habit_Logger_Me.Models;
using Habit_Logger_Me.Repositories;

namespace Habit_Logger_Me.Services;

public class HabitService
{
    private readonly IHabitRepository _habitRepository;

    public HabitService(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }


    public void CreateHabit(Habit habit)
    {  
         _habitRepository.InsertHabits(habit);
    }

    public List<Habit> GetAllHabits()
    {
        return _habitRepository.GetAllHabits();
    }

    public void UpdateHabit(Habit habit)
    {
        if (!_habitRepository.ExistsId(habit.Id))
        {
            throw new ArgumentException("The habit is not exist");
        }

        _habitRepository.UpdateHabit(habit);
    }

    public void DeleteHabit(int id)
    {
        if (!_habitRepository.ExistsId(id))
        {
            throw new ArgumentException("The habit is not exist");
        }

        _habitRepository.DeleteHabit(id);
    }
}
