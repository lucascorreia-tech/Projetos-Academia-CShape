using System;
using HabitLogger.Domain;
using HabitLogger.Application.Common;

namespace HabitLogger.Application.Interface;

public interface IHabitRepository
{
    void Insert(Habit habit);
    List<Habit> GetAll();
    Habit? GetById(long id);
    bool Update(Habit habit);
    bool Delete(long id);
}
