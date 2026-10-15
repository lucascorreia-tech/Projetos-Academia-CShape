using HabitLogger.Application.Interface;
using HabitLogger.Domain;
using HabitLogger.Infrastructure.Database;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Infrastructure.Repositories;

public class HabitRepository : IHabitRepository
{
    private readonly DbConnectionFactory _factory;

    public HabitRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    private static Habit Map(SqliteDataReader reader)
    {
        return new Habit(
            reader.GetInt64(0),
            reader.GetString(1),
            reader.GetString(2)
        );
    }

    public void Insert(Habit habit)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();
        cmd.Parameters.AddWithValue("$name", habit.Name);
        cmd.Parameters.AddWithValue("$unit", habit.UnitOfMeasure);
        cmd.CommandText = "INSERT INTO Habits (Name, UnitOfMeasure) VALUES ($name,$unit)";
        cmd.ExecuteNonQuery();
    }

    public List<Habit> GetAll()
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();

        cmd.CommandText = "SELECT Id, Name, UnitOfMeasure FROM Habits ORDER BY Name";

        using var reader = cmd.ExecuteReader();
        var habits = new List<Habit>();

        while (reader.Read()) habits.Add(Map(reader));

        return habits;
    }

    public Habit? GetById(long id)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();

        cmd.CommandText = "SELECT Id, Name, UnitOfMeasure FROM Habits WHERE Id = $id";
        cmd.Parameters.AddWithValue("$id",id);

        using var reader = cmd.ExecuteReader();
        return reader.Read() ? Map(reader) : null;
    }

    public bool Update(Habit habit)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();

        cmd.CommandText = "UPDATE Habits SET Name = $name, UnitOfMeasure = $unit WHERE Id = $id";
        cmd.Parameters.AddWithValue("$name", habit.Name);
        cmd.Parameters.AddWithValue("$unit", habit.UnitOfMeasure);
        cmd.Parameters.AddWithValue("$id", habit.Id);

        return cmd.ExecuteNonQuery() > 0;
    }

     public bool Delete(long id)
    {
        using var connection = _factory.Create();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "DELETE FROM Habit WHERE Id = $id";
        cmd.Parameters.AddWithValue("$id", id);

        return cmd.ExecuteNonQuery() > 0;
    }
}
