using System;
using HabitLogger.Application.Interface;

namespace HabitLogger.Application.Service;

public class HabitService
{
    private readonly IHabitRepository _habitRepository;

    public HabitService(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }
    
}
