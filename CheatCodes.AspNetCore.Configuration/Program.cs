using CheatCodes.AspNetCore.Configuration;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("-----arguments-----");
foreach (var arg in args)
    Console.WriteLine(arg);
Console.WriteLine();


Console.WriteLine("-----configurations-----");
builder.Configuration.PrintAll();
Console.WriteLine();

Console.WriteLine("-----configurations using debugview-----");
Console.WriteLine(builder.Configuration.GetDebugView());
Console.WriteLine();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
