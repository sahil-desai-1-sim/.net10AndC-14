namespace c14;

public static class NullConditionalAssignment
{
    public static void Run()
    {
        Console.WriteLine("--- Null-Conditional Assignment (C# 14)");

        Console.WriteLine(" Before: if (point is not null) { point.X = 2; }");
        Console.WriteLine(" After: point?.X = 2;");
    }
}