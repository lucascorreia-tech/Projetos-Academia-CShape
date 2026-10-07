namespace Habit_Logger_Me.Infra;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        using var connection = DatabaseConnection.Open();
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