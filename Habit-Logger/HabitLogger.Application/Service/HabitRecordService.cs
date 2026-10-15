using System;
using HabitLogger.Application.Interface;

namespace HabitLogger.Application.Service;

public class HabitRecordService
{
    private readonly IHabitRecordRepository _habitRecordRepository;

    public HabitRecordService(IHabitRecordRepository habitRecordRepository)
    {
        _habitRecordRepository = habitRecordRepository;
    }
}
