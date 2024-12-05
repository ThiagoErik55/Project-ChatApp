using ChatApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatAppDbContext>(options =>
    options.UseSqlite("Data Source=chatapp.db"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
