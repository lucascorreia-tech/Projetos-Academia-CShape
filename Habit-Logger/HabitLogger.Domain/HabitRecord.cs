using System;

namespace HabitLogger.Domain;

public class HabitRecord
{
    public long Id {get; private set;}
    public long HabitId {get; private set;}
    public DateOnly Date {get; private set;}
    public int Quantity {get; private set;}

    public HabitRecord(long id, long habitId, DateOnly date, int quantity)
    {
        Id = id;
        HabitId = habitId;
        Date = date;
        Quantity = quantity;
    }

    public HabitRecord(long habitId, DateOnly date, int quantity)
    {
        HabitId = habitId;
        Date = date;
        Quantity = quantity;
    }
}
