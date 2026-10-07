using Microsoft.Data.Sqlite;

namespace Habit_Logger_Me.Infra;

public static class DatabaseConnection
{
    private const string ConnectionString = @"Data source=habit.db";
    public static SqliteConnection Open()
    {
        var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var pragma = connection.CreateCommand();
        pragma.CommandText = "PRAGMA foreign_keys = ON;";
        pragma.ExecuteNonQuery();

        return connection;
    }
}