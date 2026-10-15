using System;
using System.ComponentModel;
using HabitLogger.Application.Common;
using HabitLogger.Application.Interface;
using HabitLogger.Domain;

namespace HabitLogger.Application.Service;

public class HabitRecordService
{
    private readonly IHabitRecordRepository _habitRecordRepository;

    public HabitRecordService(IHabitRecordRepository habitRecordRepository)
    {
        _habitRecordRepository = habitRecordRepository;
    }

    public Result Add(long habitId, DateOnly date, int quantity)
    {
        if (habitId <= 0)
        {
            return Result.Fail("Id is not valid.");
        }

        try
        {
            _habitRecordRepository.Insert(new HabitRecord(habitId, date, quantity));
            return Result.Ok();
        }
        catch (Exception)
        {
            return Result.Fail("Error creating the record");
        }
        
    }

    public Result<List<HabitRecord>> GetAllByHabitId(long habitId)
    {
        try
        {
            return Result<List<HabitRecord>>.Ok(_habitRecordRepository.GetAllByHabitId(habitId));
        }
        catch (Exception)
        {
            return Result<List<HabitRecord>>.Fail("Error listing the records for this habit.");
        }
    }

    public Result Update(HabitRecord habitRecord)
    {
        if (habitRecord.HabitId <= 0)
        {
            return Result.Fail("Record id must be greater than 0.");
        }

        try
        {
            return _habitRecordRepository.Update(habitRecord)
                ? Result.Ok()
                : Result.Fail("Record not found.");
        }
        catch (Exception)
        {
            return Result.Fail("Error updating the record.");
        }
    }

    public Result Delete(long id)
    {
        if (id <= 0)
        {
            return Result.Fail("Id must be greater than 0.");
        }

        try
        {
            return _habitRecordRepository.Delete(id)
                ? Result.Ok()
                : Result.Fail("Record not found.");
        }
        catch (Exception)
        {
            return Result.Fail("Error deleting the record.");
        }
    }
}