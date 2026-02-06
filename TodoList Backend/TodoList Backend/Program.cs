using TodoList_Backend.Data;
using TodoList_Backend.Data.Interfaces;
using TodoList_Backend.Services.Implementations;
using TodoList_Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IToDoTaskService, ToDoTaskServiceImpl>();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IToDoRepository, ToDo_Repository>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();