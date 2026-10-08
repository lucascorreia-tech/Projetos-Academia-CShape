using System;
using Habit_Logger_Me.Models;
using Habit_Logger_Me.Repositories;

namespace Habit_Logger_Me.Services;

public class RecordService
{
    private readonly IRecordHepository _recordHepository;

    public RecordService(IRecordHepository recordHepository)
    {
        _recordHepository = recordHepository;
    }

    public void CreateRecord(Record record)
    {
        _recordHepository.InsertRecord(record);
    }

    public List<Record> GetRecordsByHabitId(int habitId)
    {
        return _recordHepository.GetRecordsByHabitId(habitId);
    }

    public void UpdateRecord(Record record)
    {
        if (!_recordHepository.ExistsId(record.Id))
        {
            throw new ArgumentException("The Record is not exist");
        }
        _recordHepository.UpdateRecord(record);
    }

    public void DeleteRecord(int id)
    {
        if (!_recordHepository.ExistsId(id))
        {
            throw new ArgumentException("The Record is not exist");
        }
        _recordHepository.DeleteRecord(id);
    }
}
