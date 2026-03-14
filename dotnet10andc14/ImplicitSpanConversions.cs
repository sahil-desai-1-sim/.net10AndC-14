namespace dotnet10andc14;

public static class ImplicitSpanConversions
{
    public static void Run()
    {
        Console.WriteLine("--- Implicit Span Conversions (C# 14)");

        int[] numbers = [1, 2, 3, 4, 5];
        
        ProcessNumbers(numbers);
        
        DisplayNumbers(numbers);
        
        Console.WriteLine(" Original array unchanged: " + string.Join(", ", numbers));
    }

    private static void ProcessNumbers(Span<int> numbers)
    {
        Console.Write(" Processing (Span): ");
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] *= 2;
            Console.Write($"{numbers[i]} ");
        }
        Console.WriteLine();
    }

    private static void DisplayNumbers(ReadOnlySpan<int> numbers)
    {
        Console.Write(" Displaying (ReadOnlySpan): ");
        foreach (var num in numbers)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
    }
}
