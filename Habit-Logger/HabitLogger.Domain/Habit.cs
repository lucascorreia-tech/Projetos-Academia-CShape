namespace HabitLogger.Domain;

public class Habit
{
    public long Id {get; private set;}
    public string Name {get; private set;}
    public string UnitOfMeasure {get; private set;}

    public Habit(string name, string unitOfMeasure)
    {
        Name = name;
        UnitOfMeasure = unitOfMeasure;
    }

    public Habit(long id, string name, string unitOfMeasure)
    {
        Id = id;
        Name = name;
        UnitOfMeasure = unitOfMeasure;
    }
}
