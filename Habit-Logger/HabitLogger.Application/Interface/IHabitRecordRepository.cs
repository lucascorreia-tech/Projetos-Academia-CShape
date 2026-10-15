using System;
using HabitLogger.Domain;
using HabitLogger.Application.Common;

namespace HabitLogger.Application.Interface;

public interface IHabitRecordRepository
{
    public Result Insert(HabitRecord habitRecord);
    public Result<List<HabitRecord>> GetAllByHabitId(long habitId);
    public Result Update(HabitRecord habitRecord);
    public Result Delete(long id);
}
