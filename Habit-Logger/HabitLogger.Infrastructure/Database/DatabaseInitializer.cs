using System;

namespace HabitLogger.Infrastructure.Database;

public class DatabaseInitializer
{
    private readonly DbConnectionFactory _factory;

    public DatabaseInitializer(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public void Initalize()
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();

        cmd.CommandText = """
            CREATE TABLE IF NOT EXISTS Habits (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                UnitOfMeasure TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS HabitRecords (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                HabitId INTEGER NOT NULL,
                Date TEXT NOT NULL,
                Quantity INTEGER NOT NULL,
                FOREIGN KEY (habitId) REFERENCES Habits(Id) ON DELETE CASCADE
            );
            """;

        cmd.ExecuteNonQuery();
    }
}
