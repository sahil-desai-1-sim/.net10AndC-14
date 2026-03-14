using Microsoft.EntityFrameworkCore;
using dotnet10;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<SampleDbContext>(
    options => options.UseInMemoryDatabase("EFCore10Demo"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SampleDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/leftjoin", async (SampleDbContext context) =>
{
    var leftJoinQuery = context.Students
        .LeftJoin(
            context.Departments,
            student => student.DepartmentID,
            department => department.ID,
            (student, department) => new 
            { 
                student.FirstName,
                student.LastName,
                Department = department != null ? department.Name : "[NONE]"
            });

    var results = await leftJoinQuery.ToListAsync();

    return Results.Ok(results);
});

app.Run();