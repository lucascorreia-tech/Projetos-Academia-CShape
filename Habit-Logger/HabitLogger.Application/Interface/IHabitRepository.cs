using System;
using HabitLogger.Domain;
using HabitLogger.Application.Common;

namespace HabitLogger.Application.Interface;

public interface IHabitRepository
{
    public Result Insert(Habit habit);
    public Result<List<Habit>> GetAll();
    public Result<Habit> GetById(long id);
    public Result Update(Habit habit);
    public Result Delete(long id);
}
