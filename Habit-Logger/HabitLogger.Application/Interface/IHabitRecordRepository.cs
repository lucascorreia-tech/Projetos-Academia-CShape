using System;
using HabitLogger.Domain;


namespace HabitLogger.Application.Interface;

public interface IHabitRecordRepository
{
    void Insert(HabitRecord habitRecord);
    List<HabitRecord>? GetAllByHabitId(long habitId);
    bool Update(HabitRecord habitRecord);
    bool Delete(long id);
}
