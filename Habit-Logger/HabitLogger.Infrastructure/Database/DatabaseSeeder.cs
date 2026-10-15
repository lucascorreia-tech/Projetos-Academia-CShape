using System;
using System.Runtime.InteropServices;

namespace HabitLogger.Infrastructure.Database;

public class DatabaseSeeder
{
    private readonly DbConnectionFactory _factory;

    public DatabaseSeeder(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public void Seed()
    {
        using var connection = _factory.Create();

        using (var check = connection.CreateCommand())
        {
            check.CommandText = "SELECT COUNT(*) FROM Habits";
            if ((long)check.ExecuteScalar()! > 0) return;
        }

        using var transaction = connection.BeginTransaction();
        var random = new Random();

        var habits = new [] { ("Water", "glass"), ("Run", "km"), ("Reader", "pages")};

        foreach (var (name, unit) in habits)
        {
            long habitId;

            using (var cmd = connection.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO Habits (Name, UnitOfMeasure) VALUES ($name, $unit); SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("$name", name);
                cmd.Parameters.AddWithValue("$unit", unit);
                habitId = (long)cmd.ExecuteScalar()!;
            }

            for (int i = 0; i < 100; i++)
            {
                using var cmd = connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO HabitRecords (HabitId, Date, Quantity) VALUES ($habitId, $date, $quantity)";
                cmd.Parameters.AddWithValue("$habitId", habitId);
                cmd.Parameters.AddWithValue("$date", DateTime.Today.AddDays(-i).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("$quantity", random.Next(1, 100));
                cmd.ExecuteNonQuery();
            }
        }

        transaction.Commit();
    }
}
