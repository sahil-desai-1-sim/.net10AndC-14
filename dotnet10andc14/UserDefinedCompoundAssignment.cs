namespace dotnet10andc14;

public static class UserDefinedCompoundAssignment
{
    public static void Run()
    {
        Console.WriteLine("--- User-Defined Compound Assignment (C# 14)");

        var vec1 = new Vector2D(3, 4);
        var vec2 = new Vector2D(1, 2);
        
        Console.WriteLine($" Initial: {vec1}");
        
        vec1 += vec2;
        Console.WriteLine($" After += {vec2}: {vec1}");
        
        vec1 *= 2;
        Console.WriteLine($" After *= 2: {vec1}");
    }
}

public struct Vector2D
{
    public double X { get; set; }
    public double Y { get; set; }

    public Vector2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Operator for addition
    public static Vector2D operator +(Vector2D a, Vector2D b)
        => new Vector2D(a.X + b.X, a.Y + b.Y);

    // Operator for scalar multiplication
    public static Vector2D operator *(Vector2D v, double scalar)
        => new Vector2D(v.X * scalar, v.Y * scalar);

    public override string ToString() => $"({X}, {Y})";
}
