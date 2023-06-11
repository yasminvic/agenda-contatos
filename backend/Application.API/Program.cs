using Application.Service.MySQLServices;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Infra.Data.Repository.Context;
using Infra.Data.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Connection to DataBase
string ConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<MySQLContext>
    (option => option.UseSqlServer(ConnectionString));

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactService, ContactService>();


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
