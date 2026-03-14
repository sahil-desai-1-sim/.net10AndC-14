using Microsoft.EntityFrameworkCore;

namespace dotnet10;

public class Student
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int? DepartmentID { get; set; }
}

public class Department
{
    public int ID { get; set; }
    public required string Name { get; set; }
}

public class Blog
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
}

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data for Students
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "John", LastName = "Doe", DepartmentID = 1 },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DepartmentID = 2 },
            new Student { Id = 3, FirstName = "Bob", LastName = "Johnson", DepartmentID = null }, // Student with no department
            new Student { Id = 4, FirstName = "Alice", LastName = "Williams", DepartmentID = 1 }
        );

        // Seed data for Departments
        modelBuilder.Entity<Department>().HasData(
            new Department { ID = 1, Name = "Computer Science" },
            new Department { ID = 2, Name = "Mathematics" },
            new Department { ID = 3, Name = "Physics" } // Department with no students
        );

        // Seed data for Blogs
        modelBuilder.Entity<Blog>().HasData(
            new Blog { Id = 1, Name = "Tech Blog", Category = "Technology" },
            new Blog { Id = 2, Name = "Science Blog", Category = "Science" },
            new Blog { Id = 3, Name = "Math Blog", Category = "Education" },
            new Blog { Id = 4, Name = "Coding Tips", Category = "Technology" },
            new Blog { Id = 5, Name = "AI Trends", Category = "Technology" }
        );
    }
}
