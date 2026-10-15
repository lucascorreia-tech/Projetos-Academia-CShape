using System;
using System.Globalization;
using HabitLogger.Application.Interface;
using HabitLogger.Domain;
using HabitLogger.Infrastructure.Database;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Infrastructure.Repositories;

public class HabitRecordRepository : IHabitRecordRepository
{
    private const string DateFormat = "yyyy-MM-dd";
    private readonly DbConnectionFactory _factory;

    public HabitRecordRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    private static HabitRecord Map(SqliteDataReader reader)
    {
        return new HabitRecord(
            reader.GetInt64(0),
            reader.GetInt64(1),
            DateOnly.ParseExact(reader.GetString(2), DateFormat, CultureInfo.InvariantCulture),
            reader.GetInt32(3)
        );
    }

    public void Insert(HabitRecord habitRecord)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO HabitRecords (HabitId, Date, Quantity) VALUES ($habitId, $date, $quantity)";
        cmd.Parameters.AddWithValue("$habitId",habitRecord.HabitId);
        cmd.Parameters.AddWithValue("$date",habitRecord.Date);
        cmd.Parameters.AddWithValue("$quantity",habitRecord.Quantity);
        cmd.ExecuteNonQuery();
    }

    public List<HabitRecord>? GetAllByHabitId(long habitId)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT Id, HabitId, Date, Quantity FROM HabitRecords WHERE HabitId = $habitId";
        cmd.Parameters.AddWithValue("$habitId", habitId);

        var reader = cmd.ExecuteReader();

        var records = new List<HabitRecord>();

        while (reader.Read()) records.Add(Map(reader));

        return records.Count == 0 ? null : records;
    }

    public bool Update(HabitRecord habitRecord)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();

        cmd.CommandText = "UPDATE HabitRecords SET Quantity = $quantity, Date = $date WHERE Id = $id";
        cmd.Parameters.AddWithValue("$quantity", habitRecord.Quantity);
        cmd.Parameters.AddWithValue("$date", habitRecord.Date);
        cmd.Parameters.AddWithValue("$id", habitRecord.Id);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Delete(long id)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();

        cmd.CommandText = "DELETE FROM HabitRecords WHERE Id = $id";
        cmd.Parameters.AddWithValue("$id", id);

        return cmd.ExecuteNonQuery() > 0;
    }
}
