namespace Habit_Logger_Me.Models;

public class Record
{
    public int Id {get; set;}
    public int Id_Habit {get; set;}
    public DateTime Date {get; set;}
    public int Quantity {get; set;}

    public Record(int id, int id_Habit, DateTime date, int quantity)
    {
        Id = id;
        Id_Habit = id_Habit;
        Date = date;
        Quantity = quantity;
    }
}
