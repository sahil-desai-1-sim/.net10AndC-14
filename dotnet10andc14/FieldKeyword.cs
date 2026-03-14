namespace dotnet10andc14;

public static class FieldKeyword
{
    public static void Run()
    {
        Console.WriteLine("--- The field keyword (C# 14)");

        var product = new Product
        {
            Name = "Laptop",
            Price = 999.99m
        };

        Console.WriteLine($" Product: {product.Name}, Price: ${product.Price}");

        try
        {
            product.Name = null!;
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine(" ✓ Name cannot be null - validation works!");
        }

        product.Price = -50;
        Console.WriteLine($" After setting negative price: ${product.Price}");
    }
}

public class Product
{
    public required string Name
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    }

    public decimal Price
    {
        get;
        set => field = value < 0 ? 0 : value;
    }
}
