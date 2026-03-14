namespace dotnet10andc14;

public static class UnboundGenericAndNameof
{
    public static void Run()
    {
        Console.WriteLine("--- Unbound Generic Types with nameof (C# 14)");

        Console.WriteLine($" Old way (closed generic): {nameof(List<int>)}");
        
        LogGenericType<string, int>();
    }

    private static void LogGenericType<TKey, TValue>()
    {
        Console.WriteLine($" ✓ Working with {nameof(Dictionary<,>)}<{typeof(TKey).Name}, {typeof(TValue).Name}>");
    }
}
