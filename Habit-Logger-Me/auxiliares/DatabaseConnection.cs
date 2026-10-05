using System;
using Microsoft.Data.Sqlite;

namespace Habit_Logger_Me;

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

    public static void Initialize()
    {
        using var connection = Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Habits (
                Id_Habit INTEGER PRIMARY KEY AUTOINCREMENT,
                Habit TEXT NOT NULL,
                Unit TEXT NOT NULL
            ); 

            CREATE TABLE IF NOT EXISTS Records (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Id_Habit INTEGER NOT NULL,
                Date TEXT NOT NULL,
                Quantity INTEGER NOT NULL,
                FOREIGN KEY (Id_Habit) REFERENCES Habits(Id_Habit)
            );";
            command.ExecuteNonQuery();
    }
}
