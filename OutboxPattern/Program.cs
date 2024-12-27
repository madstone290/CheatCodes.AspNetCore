using Microsoft.EntityFrameworkCore;
using OutboxPattern.Core.Infrastructure;
using OutboxPattern.Core.Infrastructure.OutboxMessageHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=ApplicationDb.db");
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<OutboxMessagePublisher>();
builder.Services.AddScoped<OutboxMessageProcessor>();
builder.Services.AddScoped<IOutboxMessageHandler, NotificationMessageHandler>();
builder.Services.AddScoped<IOutboxMessageHandler, EmailMessageHandler>();

builder.Services.AddHostedService<OutboxBackgroundService>();

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

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
