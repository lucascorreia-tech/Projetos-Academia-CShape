using System;
using HabitLogger.Application.Common;
using HabitLogger.Application.Interface;
using HabitLogger.Domain;

namespace HabitLogger.Application.Service;

public class HabitService
{
    private readonly IHabitRepository _habitRepository;

    public HabitService(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }

    public Result Add(string name, string unitOfMeasure)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Fail("The name of the habit is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(unitOfMeasure))
        {
            return Result.Fail("The unit of measurement is mandatory.");
        }

        try
        {
            _habitRepository.Insert(new Habit(name.Trim(), unitOfMeasure.Trim()));
            return Result.Ok();
        }
        catch (Exception)
        {
            return Result.Fail("Error creating the habit.");
        }
    }

    public Result<List<Habit>> GetAll()
    {
        try
        {
            return Result<List<Habit>>.Ok(_habitRepository.GetAll());
        }
        catch (Exception)
        {
            return Result<List<Habit>>.Fail("Error listing the habits.");
        }
    }

    public Result<Habit> GetById(long id)
    {
        if (id <= 0)
        {
            return Result<Habit>.Fail("Id must be greater than 0.");
        }

        try
        {
            var habit = _habitRepository.GetById(id);

            return habit is null
                ? Result<Habit>.Fail("Habit not found or does not exist.")
                : Result<Habit>.Ok(habit);
        }
        catch (Exception)
        {
            return Result<Habit>.Fail("Error fetching the habit.");
        }
    }

    public Result Update(Habit habit)
    {
        if (string.IsNullOrWhiteSpace(habit.Name))
            return Result.Fail("The name of the habit is mandatory.");

        if (string.IsNullOrWhiteSpace(habit.UnitOfMeasure))
            return Result.Fail("The unit of measurement is mandatory.");

        if (habit.Id <= 0)
        {
            return Result<Habit>.Fail("Id must be greater than 0.");
        }

        try
        {
            return _habitRepository.Update(habit)
                ? Result.Ok()
                : Result.Fail("Habit not found.");
        }
        catch (Exception)
        {
            return Result.Fail("Error updating the habit.");
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
            return _habitRepository.Delete(id)
                ? Result.Ok()
                : Result.Fail("Habit not found.");
        }
        catch (Exception)
        {
            return Result.Fail("Error deleting the habit.");
        }
    }
}