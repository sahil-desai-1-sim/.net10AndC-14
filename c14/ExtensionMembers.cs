
namespace c14;

public static class ExtensionMembers
{
    public static void Run()
    {
        Console.WriteLine("--- Getting Start & End day of current week (Extension Members)");

        (var startDateOld, var endDateOld) = DateTime.UtcNow.GetStartAndEndOfWeek();
        Console.WriteLine($" Old way => {startDateOld} -> {endDateOld}");
        
        (var startDateNew, var endDateNew) = DateTime.UtcNow.GetStartAndEndOfWeek();
        Console.WriteLine($" New way => {startDateNew} -> {endDateNew}");
    }

    public static (DateTime startOfWeek, DateTime EndOfWeek) GetStartAndEndOfWeek(this DateTime date)
    {
        int diff = (DayOfWeek.Monday - date.DayOfWeek) % 7;
        var startOfWeek = date.AddDays(diff).Date;
        return (startOfWeek,startOfWeek.AddDays(6));
    }

    extension(DateTime date) 
    {
        public (DateTime startOfWeek, DateTime EndOfWeek) GetStartAndEndOfWeekNew 
            => GetStartAndEndOfWeek(date);
    }
}