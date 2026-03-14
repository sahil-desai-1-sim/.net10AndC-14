namespace c14;

public static class PartialMembers
{
    public static void Run()
    {
        Console.WriteLine("--- Partial Constructors and Events (C# 14)");

        var employee = new Employee("Alice", "Engineering");
        employee.OnSalaryChanged += (sender, salary) => 
            Console.WriteLine($" Event fired: Salary changed to ${salary}");
        
        employee.UpdateSalary(75000);
    }
}

public partial class Employee
{
    public string Name { get; }
    public string Department { get; }
    
    public partial Employee(string name, string department);
    
    public partial event EventHandler<decimal>? OnSalaryChanged;
    
    public void UpdateSalary(decimal newSalary)
    {
        Salary = newSalary;
        _salaryChanged?.Invoke(this, newSalary);
    }
}

public partial class Employee
{
    public decimal Salary { get; private set; }
    
    public partial Employee(string name, string department)
    {
        Name = name;
        Department = department;
        Console.WriteLine($" ✓ Employee created: {Name} in {Department}");
    }
    
    public partial event EventHandler<decimal>? OnSalaryChanged
    {
        add { _salaryChanged += value; }
        remove { _salaryChanged -= value; }
    }
    
    private EventHandler<decimal>? _salaryChanged;
}
