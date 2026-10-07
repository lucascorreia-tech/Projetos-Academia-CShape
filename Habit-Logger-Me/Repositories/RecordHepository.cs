using System;
using System.Runtime.InteropServices;
using Habit_Logger_Me.Infra;
using Habit_Logger_Me.Models;

namespace Habit_Logger_Me.Repositories;

public class RecordHepository : IRecordHepository
{
    public void CreateRecord(Record record)
    {
        using var connection = DatabaseConnection.Open();
        using var command = connection.CreateCommand();
        command.Parameters.AddWithValue("$Id_Habit", record.Id_Habit);
        command.Parameters.AddWithValue("$Date", record.Date);
        command.Parameters.AddWithValue("$Quantity", record.Quantity);
        command.CommandText = @"INSERT INTO Records (Id_habit, Date, Quantity) VALUES ($Id_Habit, $Date, $Quantity);";
        command.ExecuteNonQuery();
    }

    public void DeleteRecord(int id)
    {
        using var connection = DatabaseConnection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM Records WHERE Id = $Id";
        command.Parameters.AddWithValue("$Id", id);
        command.ExecuteNonQuery();
    }

    public bool ExistsId(int id)
    {
        using var connection = DatabaseConnection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT 1 FROM Records WHERE Id = $Id";
        command.Parameters.AddWithValue("$Id",id);
        return command.ExecuteScalar() is not null;
    }

    public List<Record> GetRecordsByHabitId(int habitId)
    {
        List<Record> RecordList = new List<Record>();
        using var connection = DatabaseConnection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT Id, Date, Quantity FROM Records WHERE Id_Habit = $habitId";
        command.Parameters.AddWithValue("$habitId", habitId);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            RecordList.Add(new Record(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetDateTime(2),
                reader.GetInt32(3)
            ));
        }

        return RecordList;
    }

    public void UpdateRecord(Record record)
    {
        using var connection = DatabaseConnection.Open();
        using var command = connection.CreateCommand();
        command.Parameters.AddWithValue("$Date", record.Date);
        command.Parameters.AddWithValue("$Quantity", record.Quantity);
        command.Parameters.AddWithValue("$Id", record.Id);
        command.CommandText = @"UPDATE Records SET Date = $Date, Quantity = $Quantity WHERE Id = $Id";
    }
}
