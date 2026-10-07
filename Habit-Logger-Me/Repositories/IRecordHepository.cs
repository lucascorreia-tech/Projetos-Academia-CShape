using System;
using Habit_Logger_Me.Models;

namespace Habit_Logger_Me.Repositories;

public interface IRecordHepository
{
    bool ExistsId(int id);
    void CreateRecord(Record record);
    List<Record> GetRecordsByHabitId(int habitId);
    void UpdateRecord(Record record);
    void DeleteRecord(int id);
}
