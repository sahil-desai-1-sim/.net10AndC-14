namespace c14;

public static class SimpleLambdaParameters
{
    public delegate bool TryParse<T>(string text, out T result);
    
    public static void Run()
    {
        Console.WriteLine("--- Simple Lambda Parameters with Modifiers (C# 14)");

        TryParse<int> parseNew = (text, out result) => int.TryParse(text, out result);
        
        if (parseNew("42", out var value))
        {
            Console.WriteLine($" ✓ Parsed value: {value}");
        }

        ModifyValue modifyRef = (ref x) => x *= 2;
        int num = 10;
        modifyRef(ref num);
        Console.WriteLine($" ✓ After ref modification: {num}");

        DisplayValue displayIn = (in value) => Console.WriteLine($" ✓ Read-only value: {value}");
        displayIn(in num);
    }

    public delegate void ModifyValue(ref int x);
    public delegate void DisplayValue(in int value);
}
